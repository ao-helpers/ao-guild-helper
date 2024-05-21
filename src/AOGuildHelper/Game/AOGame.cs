using AOGuildHelper.Network.Packets;

namespace AOGuildHelper.Game;

public class AOGame
{
    public readonly object SyncRoot = new();
    
    public AOGuildChallenge GuildChallenge { get; set; } = new();
    public AOGuildMight GuildMight { get; set; } = new();
    
    public void UpdateFrom(GuildChallengePointsResponseMessage guildChallengePointsResponseMessage)
    {
        lock (SyncRoot)
        {
            GuildChallenge.UpdateFrom(guildChallengePointsResponseMessage);
        }
    }
    
    public void UpdateFrom(GuildMightCategoryContributionResponseMessage guildMightCategoryContributionResponseMessage)
    {
        lock (SyncRoot)
        {
            GuildMight.UpdateFrom(guildMightCategoryContributionResponseMessage);
        }
    }
}