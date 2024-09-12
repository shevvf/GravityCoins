using UnityEngine;

public class LeaderboardElementPresenter : MonoBehaviour
{
    [field: SerializeField] private LeaderboardElementView View { get; set; }
    private LeaderboardElementModel LeaderboardModel { get; set; } = new();

    public void Initialize(int currentElement)
    {
        InitializeModel();
        InitializeView(currentElement);
    }

    private void InitializeModel()
    {
        LeaderboardModel.Initialize();
    }

    private void InitializeView(int currentElement)
    {
        View.PlayerPlace.SetText((currentElement + 1).ToString());
        View.PlayerCoins.SetText(LeaderboardModel.TopPlayers[currentElement].coin.ToString());
        View.PlayerName.SetText(LeaderboardModel.TopPlayers[currentElement].nickname.ToString());
    }
}
