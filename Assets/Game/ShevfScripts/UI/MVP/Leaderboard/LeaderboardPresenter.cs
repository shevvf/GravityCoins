using System.Collections.Generic;
using System.Linq;

using Game.ShevfScripts;

using UnityEngine;

public class LeaderboardPresenter : MonoBehaviour
{
    [field: SerializeField] private WebRequesterEventHandler WebRequesterEventHandler { get; set; }
    [field: SerializeField] private LeaderboardView View { get; set; }
    [field: SerializeField] private PlayersFetch PlayersFetch { get; set; }
    private LeaderboardModel LeaderboardModel { get; set; } = new();
    private List<GameObject> LeaderboardElements { get; set; } = new();

    private void OnEnable()
    {
        PlayersFetch.Fetch();
        WebRequesterEventHandler.OnPlayersFetched += PlayerFetched;
    }

    private void OnDisable()
    {
        ClearLeaderboard();
        WebRequesterEventHandler.OnPlayersFetched -= PlayerFetched;
    }

    private void OnDestroy()
    {
        WebRequesterEventHandler.OnPlayersFetched -= PlayerFetched;
    }

    private void PlayerFetched()
    {
        InitializeModel();
        InitializeView();
    }

    private void InitializeModel()
    {
        LeaderboardModel.Initialize();
    }

    private void InitializeView()
    {
        for (int i = 0; i < LeaderboardModel.PlayersCount; i++)
        {
            GameObject newElement = Instantiate(View.LeaderboardElement, View.LeaderboardContent.position,
                 View.LeaderboardElement.transform.rotation, View.LeaderboardContent);

            LeaderboardElementPresenter leaderboardElementPresenter = newElement.GetComponent<LeaderboardElementPresenter>();
            leaderboardElementPresenter.Initialize(i);

            LeaderboardElements.Add(newElement);
        }
    }

    private void ClearLeaderboard()
    {
        LeaderboardElements.ToList().ForEach(element =>
        {
            Destroy(element);
        });
        LeaderboardElements.Clear();
    }
}
