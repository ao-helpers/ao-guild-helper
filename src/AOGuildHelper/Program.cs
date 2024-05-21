using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using AOGuildHelper.Game;
using AOGuildHelper.Network;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using Spectre.Console;
using Spectre.Console.Cli;

var app = new CommandApp<DefaultCommand>();
return app.Run(args);

internal sealed class DefaultCommand : Command<DefaultCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("--source")]
        [DefaultValue("device://auto")]
        public string Source { get; init; } = null!;

        [CommandOption("--output")]
        public string? Output { get; init; }
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        ICaptureDevice sourceDevice;
        if (settings.Source == "device://auto")
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
                .Where(a => a.NetworkInterfaceType is NetworkInterfaceType.Ethernet or NetworkInterfaceType.Wireless80211)
                .Where(a => a.OperationalStatus == OperationalStatus.Up)
                .Where(a => a.GetIPProperties().GatewayAddresses.Count != 0)
                .OrderByDescending(a => a.GetIPProperties().GetIPv4Properties().Index)
                .ToArray();
                
            var networkInterface = networkInterfaces.Last();

            sourceDevice = LibPcapLiveDeviceList.Instance
                .Where(d => d.Name.Contains(networkInterface.Id))
                .Single();
            
            AnsiConsole.WriteLine($"Listening on {networkInterface.Name} ({networkInterface.Description})");
        }
        else if (settings.Source.StartsWith("file://"))
        {
            sourceDevice = new CaptureFileReaderDevice(settings.Source[7..]);
        }
        else
        {
            throw new InvalidOperationException($"Undefined behavior for source '{settings.Source}'");
        }

        CaptureFileWriterDevice? outputDevice;
        if (settings.Output == null)
        {
            outputDevice = null;
        }
        else if (settings.Output.StartsWith("file://"))
        {
            outputDevice = new CaptureFileWriterDevice(settings.Output[7..], FileMode.Create);
            AnsiConsole.WriteLine($"Writing to {outputDevice.Name}");
        }
        else
        {
            throw new InvalidOperationException($"Undefined behavior for output '{settings.Output}'");
        }

        var game = new AOGame();
        var parser = new PacketParser(game);

        outputDevice?.Open();

        sourceDevice.Open();
        sourceDevice.Filter = "ip and udp port 5056";
        sourceDevice.OnPacketArrival += (sender, capture) =>
        {
            try
            {
                var rawCapture = capture.GetPacket();
                var packet = rawCapture.GetPacket();
                var ipPacket = packet.Extract<IPv4Packet>();
                var udpPacket = ipPacket.Extract<UdpPacket>();

                if (ipPacket.FragmentFlags > 0)
                {
                    return;
                }

                outputDevice?.Write(rawCapture);
                parser.ReceivePacket(udpPacket.PayloadData);
            }
            catch (IndexOutOfRangeException)
            {
                // Some packets throw this exception due to bug in PhotonPackageParser,
                // probably not an issue for this app.
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex);
            }
        };
        sourceDevice.StartCapture();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
            else
            {
                Thread.Sleep(10);
            }
        }

        sourceDevice.Close();
        outputDevice?.Close();

        return 0;
    }
}
