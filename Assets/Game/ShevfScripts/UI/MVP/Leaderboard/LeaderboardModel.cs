public class LeaderboardModel
{
    public int PlayersCount { get; set; }

    public void Initialize()
    {
        //PlayersCount = DataHolder.AllPlayers.Count;
        PlayersCount = 10;
    }
}
