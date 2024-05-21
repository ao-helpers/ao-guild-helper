using System.Diagnostics.CodeAnalysis;
using AOGuildHelper.Network.Internal;

namespace AOGuildHelper.Network.Packets;

public class GuildMightCategoryContributionResponseMessage
{
    public string Category { get; set; } = null!;
    public long TotalPoints { get; set; }
    public int TotalContributors { get; set; }
    public Contributor[] Contributors { get; set; } = null!;

    public static bool TryDeserialize(IDictionary<byte, object> parameters, [NotNullWhen(true)] out GuildMightCategoryContributionResponseMessage? message)
    {
        var isValid = true;

        isValid &= parameters.TryGetString(1, out var category);
        isValid &= parameters.TryGetInt64(3, out var totalPoints);
        isValid &= parameters.TryGetInt32(4, out var totalContributors);
        isValid &= parameters.TryGetArray<string>(6, out var playerNames, ConversionExtensions.TryConvertToString);
        isValid &= parameters.TryGetArray<long>(7, out var playerContributions, ConversionExtensions.TryConvertToInt64);

        isValid &= playerNames.Length == playerContributions.Length;
        
        if (isValid)
        {
            message = new GuildMightCategoryContributionResponseMessage()
            {
                Category = category,
                TotalPoints = totalPoints,
                TotalContributors = totalContributors,
                Contributors = playerNames
                    .Select((name, i) => new Contributor()
                    {
                        Name = name,
                        Amount = playerContributions[i],
                    })
                    .ToArray(),
            };
        }
        else
        {
            message = null;
        }

        return isValid;
    }
    
    #region Nested type: Contributor
    
    public class Contributor
    {
        public string Name { get; set; } = null!;
        public long Amount { get; set; }
    }
    
    #endregion
}
