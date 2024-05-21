using System.Text;
using AOGuildHelper.Game;
using AOGuildHelper.Network.Packets;
using PhotonPackageParser;
using Spectre.Console;

namespace AOGuildHelper.Network;

public class PacketParser(AOGame game) : PhotonParser
{
    public AOGame Game { get; } = game ?? throw new ArgumentNullException(nameof(game));

    private bool Filter(string message)
    {
        return false;
    }

    protected override void OnRequest(byte operationCode, Dictionary<byte, object> parameters)
    {
        var builder = new StringBuilder();

        parameters.TryGetValue(253, out var typeObj);

        if (typeObj is not short type)
        {
            //builder.AppendLine($"Request Code={operationCode} Type=<unknown{(typeObj == null ? null : $" {typeObj.GetType().Name}")}>");
            return;
        }
        else
        {
            var operationKind = (AOOperationKind)type;

            builder.AppendLine($"Request Code={operationCode} Kind={operationKind} ({((int)operationKind)})");
        }

        var message = builder.ToString();
        if (Filter(message))
        {
            AnsiConsole.Write(message);
        }
    }

    protected override void OnResponse(byte operationCode, short returnCode, string debugMessage, Dictionary<byte, object> parameters)
    {
        var builder = new StringBuilder();

        parameters.TryGetValue(253, out var typeObj);

        if (typeObj is not short type)
        {
            //builder.AppendLine($"Response Code={operationCode} Kind=<unknown{(typeObj == null ? null : $" {typeObj.GetType().Name}")}> ReturnCode={returnCode} DebugMessage={debugMessage}");
            return;
        }
        else
        {
            var operationKind = (AOOperationKind)type;

            builder.AppendLine($"Response Code={operationCode} Kind={operationKind} ({((int)operationKind)})");

            switch (operationKind)
            {
                case AOOperationKind.GetGuildChallengePoints:
                    if (GuildChallengePointsResponseMessage.TryDeserialize(parameters, out var guildChallengePointsResponseMessage))
                    {
                        Game.UpdateFrom(guildChallengePointsResponseMessage);
                    }
                    break;
                
                case AOOperationKind.GetGuildMightCategoryContribution:
                    if (GuildMightCategoryContributionResponseMessage.TryDeserialize(parameters, out var guildMightCategoryContributionResponseMessage))
                    {
                        Game.UpdateFrom(guildMightCategoryContributionResponseMessage);
                    }
                    break;
            }
        }

        var message = builder.ToString();
        if (Filter(message))
        {
            AnsiConsole.Write(message);
        }
    }

    protected override void OnEvent(byte eventCode, Dictionary<byte, object> parameters)
    {
        var builder = new StringBuilder();

        parameters.TryGetValue(252, out var typeObj);

        if (typeObj is not short type)
        {
            //builder.AppendLine($"Event Code={eventCode} Kind=<unknown{(typeObj == null ? null : $" {typeObj.GetType().Name}")}>");
            return;
        }
        else
        {
            var eventKind = (AOEventKind)type;

            builder.AppendLine($"Event Code={eventCode} Kind={eventKind} ({((int)eventKind)})");
        }

        var message = builder.ToString();
        if (Filter(message))
        {
            AnsiConsole.Write(message);
        }
    }
}