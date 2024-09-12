using UnityEngine;

public class PlayersFetch : MonoBehaviour
{
    [field: SerializeField] private WebRequester WebRequester { get; set; }

    public void Fetch()
    {
        StartCoroutine(WebRequester.GetAllPlayers(WebRequestSettings.REQUEST_ALL_PLAYERS_URL));
    }
}
