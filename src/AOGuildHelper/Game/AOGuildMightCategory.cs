using System.Globalization;
using System.Text;
using AOGuildHelper.Network.Packets;
using Spectre.Console;

namespace AOGuildHelper.Game;

public class AOGuildMightCategory
{
    public AOGuildMightCategory(string category)
    {
        Category = category ?? throw new ArgumentNullException(nameof(category));
    }

    public string Category { get; }
    public double TotalPoints { get; set; }
    public int TotalContributors { get; set; }
    public List<AOGuildMightContributor> Contributors { get; set; } = new();

    public bool IsComplete => TotalContributors > 0 && Contributors.Count == TotalContributors;
    
    public void UpdateFrom(GuildMightCategoryContributionResponseMessage guildMightCategoryContributionResponseMessage)
    {
        var timestamp = DateTime.UtcNow;

        var wasComplete = IsComplete;
        
        TotalPoints = guildMightCategoryContributionResponseMessage.TotalPoints / 10000.0;

        if (TotalContributors != guildMightCategoryContributionResponseMessage.TotalContributors)
        {
            TotalContributors = guildMightCategoryContributionResponseMessage.TotalContributors;
            Contributors = new List<AOGuildMightContributor>();
        }

        var added = 0;
        var updated = 0;
        foreach (var newContributor in guildMightCategoryContributionResponseMessage.Contributors)
        {
            var contributed = newContributor.Amount / 10000.0;
            
            var currentContributor = Contributors.Find(x => x.Name == newContributor.Name);
            if (currentContributor == null)
            {
                Contributors.Add(new AOGuildMightContributor()
                {
                    Name = newContributor.Name,
                    Amount = contributed,
                });
                added += 1;
            }
            else if (Math.Abs(currentContributor.Amount - contributed) > 0.0001)
            {
                updated += 1;
            }
        }
        
        AnsiConsole.WriteLine($"Might {Category}: Added {added}, updated {updated} out of {guildMightCategoryContributionResponseMessage.Contributors.Length} (total {guildMightCategoryContributionResponseMessage.TotalContributors} contributors)");

        if (!wasComplete && IsComplete)
        {
            var path = $"might-points-{Category}-{DateTime.UtcNow:yyyy-MM-dd_HHmmss}.csv";
            
            AnsiConsole.WriteLine($"Might {Category}: Writing to {path}");

            using var stream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(stream, new UTF8Encoding(false));

            writer.WriteLine($"Name,Amount,Timestamp");
            foreach (var contributor in Contributors.OrderByDescending(x => x.Amount))
            {
                writer.WriteLine($"{contributor.Name},{contributor.Amount.ToString(CultureInfo.InvariantCulture)},{timestamp.ToString("o", CultureInfo.InvariantCulture)}");
            }
        }
    }
}