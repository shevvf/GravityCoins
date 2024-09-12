using System.Collections.Generic;
using System.Linq;

public class LeaderboardElementModel
{
    public List<Player> TopPlayers { get; private set; }

    public void Initialize()
    {
        GetTop10Players();

    }

    public void GetTop10Players()
    {
        TopPlayers = DataHolder.AllPlayers.OrderByDescending(p => p.coin).Take(10).ToList();
    }
}
