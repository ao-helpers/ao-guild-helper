using System.Diagnostics.CodeAnalysis;
using AOGuildHelper.Network.Internal;

namespace AOGuildHelper.Network.Packets;

public class GuildChallengePointsResponseMessage
{
    public int TotalPoints { get; set; }
    public int TotalContributors { get; set; }
    public Contributor[] Contributors { get; set; } = null!;

    public static bool TryDeserialize(IDictionary<byte, object> parameters, [NotNullWhen(true)] out GuildChallengePointsResponseMessage? message)
    {
        var isValid = true;

        isValid &= parameters.TryGetInt32(2, out var totalPoints);
        isValid &= parameters.TryGetInt32(3, out var totalContributors);
        isValid &= parameters.TryGetArray<string>(5, out var playerNames, ConversionExtensions.TryConvertToString);
        isValid &= parameters.TryGetArray<int>(6, out var playerContributions, ConversionExtensions.TryConvertToInt32);

        isValid &= playerNames.Length == playerContributions.Length;
        
        if (isValid)
        {
            message = new GuildChallengePointsResponseMessage()
            {
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
        public int Amount { get; set; }
    }
    
    #endregion
}
