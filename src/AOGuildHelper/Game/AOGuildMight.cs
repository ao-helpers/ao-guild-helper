using AOGuildHelper.Network.Packets;

namespace AOGuildHelper.Game;

public class AOGuildMight
{
    public Dictionary<string, AOGuildMightCategory> Categories { get; set; } = new();

    public void UpdateFrom(GuildMightCategoryContributionResponseMessage guildMightCategoryContributionResponseMessage)
    {
        if (!Categories.TryGetValue(guildMightCategoryContributionResponseMessage.Category, out var category))
        {
            Categories.Add(guildMightCategoryContributionResponseMessage.Category, category = new AOGuildMightCategory(guildMightCategoryContributionResponseMessage.Category));
        }
        category.UpdateFrom(guildMightCategoryContributionResponseMessage);
    }
}