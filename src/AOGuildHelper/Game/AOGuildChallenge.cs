using System.Globalization;
using System.Text;
using AOGuildHelper.Network.Packets;
using Spectre.Console;

namespace AOGuildHelper.Game;

public class AOGuildChallenge
{
    public int TotalPoints { get; set; }
    public int TotalContributors { get; set; }
    public List<AOGuildChallengeContributor> Contributors { get; set; } = new List<AOGuildChallengeContributor>();

    public bool IsComplete => TotalContributors > 0 && Contributors.Count == TotalContributors;
    
    public void UpdateFrom(GuildChallengePointsResponseMessage guildChallengePointsResponseMessage)
    {
        var wascomplete = IsComplete;
        
        TotalPoints = guildChallengePointsResponseMessage.TotalPoints;

        if (TotalContributors != guildChallengePointsResponseMessage.TotalContributors)
        {
            TotalContributors = guildChallengePointsResponseMessage.TotalContributors;
            Contributors = new List<AOGuildChallengeContributor>();
        }

        var added = 0;
        var updated = 0;
        foreach (var newContributor in guildChallengePointsResponseMessage.Contributors)
        {
            var currentContributor = Contributors.Find(x => x.Name == newContributor.Name);
            if (currentContributor == null)
            {
                Contributors.Add(new AOGuildChallengeContributor()
                {
                    Name = newContributor.Name,
                    Amount = newContributor.Amount,
                });
                added += 1;
            }
            else if (currentContributor.Amount != newContributor.Amount)
            {
                updated += 1;
            }
        }
                
        AnsiConsole.WriteLine($"Challenge: Added {added}, updated {updated} out of {guildChallengePointsResponseMessage.Contributors.Length} (total {guildChallengePointsResponseMessage.TotalContributors} contributors)");

        if (!wascomplete && IsComplete)
        {
            var path = $"challenge-points-{DateTime.UtcNow:yyyy-MM-dd_HHmmss}.csv";
            
            AnsiConsole.WriteLine($"Challenge: Writing to {path}");

            using var stream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(stream, new UTF8Encoding(false));

            writer.WriteLine($"Name,Amount");
            foreach (var contributor in Contributors.OrderByDescending(x => x.Amount))
            {
                writer.WriteLine($"{contributor.Name},{contributor.Amount.ToString(CultureInfo.InvariantCulture)}");
            }
        }
    }
}