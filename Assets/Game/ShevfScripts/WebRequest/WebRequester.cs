using System.Collections;

using Game.ShevfScripts;

using UnityEngine;
using UnityEngine.Networking;

public class WebRequester : MonoBehaviour
{
    [field: SerializeField] private WebRequesterEventHandler WebRequesterEventHandler { get; set; }

    public IEnumerator SendData(string url, WWWForm form)
    {
        using UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            string errorMessage = $"Error: {request.error}\n";
            errorMessage += $"URL: {url}\n";
            errorMessage += $"Response Code: {request.responseCode}\n";
            errorMessage += $"Response: {request.downloadHandler.text}\n";
            errorMessage += $"Request Method: {request.method}\n";
            errorMessage += $"Request URL: {request.url}\n";
            errorMessage += $"Request Upload Data: {request.uploadHandler?.data.Length ?? 0} bytes\n";
            // errorMessage += $"Request Download Data: {request.downloadHandler?.data.Length ?? 0} bytes\n";
            Debug.LogError(errorMessage);
            yield break;
        }

        WebRequesterEventHandler.Saved();
    }

    public IEnumerator CreateNewPlayer(string url, WWWForm form)
    {
        using UnityWebRequest request = UnityWebRequest.Post(url, form);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            string errorMessage = $"Error: {request.error}\n";
            errorMessage += $"URL: {url}\n";
            errorMessage += $"Response Code: {request.responseCode}\n";
            errorMessage += $"Response: {request.downloadHandler.text}\n";
            errorMessage += $"Request Method: {request.method}\n";
            errorMessage += $"Request URL: {request.url}\n";
            errorMessage += $"Request Upload Data: {request.uploadHandler?.data.Length ?? 0} bytes\n";
            // errorMessage += $"Request Download Data: {request.downloadHandler?.data.Length ?? 0} bytes\n";
            Debug.LogError(errorMessage);
            yield break;
        }

        DataHolder.PlayerData.player = DataExtensions.SetData<Player>(request.downloadHandler.text);

        WebRequesterEventHandler.Loaded();
    }

    public IEnumerator SendRewardForInvite(string url, WWWForm form)
    {
        using UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            string errorMessage = $"Error: {request.error}\n";
            errorMessage += $"URL: {url}\n";
            errorMessage += $"Response Code: {request.responseCode}\n";
            errorMessage += $"Response: {request.downloadHandler.text}\n";
            errorMessage += $"Request Method: {request.method}\n";
            errorMessage += $"Request URL: {request.url}\n";
            errorMessage += $"Request Upload Data: {request.uploadHandler?.data.Length ?? 0} bytes\n";
            // errorMessage += $"Request Download Data: {request.downloadHandler?.data.Length ?? 0} bytes\n";
            Debug.LogError(errorMessage);
            yield break;
        }
    }

    public IEnumerator GetData(string url)
    {
        using UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            string errorMessage = $"Error: {request.error}\n";
            errorMessage += $"URL: {url}\n";
            errorMessage += $"Response Code: {request.responseCode}\n";
            errorMessage += $"Response: {request.downloadHandler.text}\n";
            errorMessage += $"Request Method: {request.method}\n";
            errorMessage += $"Request URL: {request.url}\n";
            errorMessage += $"Request Upload Data: {request.uploadHandler?.data.Length ?? 0} bytes\n";
            // errorMessage += $"Request Download Data: {request.downloadHandler?.data.Length ?? 0} bytes\n";
            Debug.LogError(errorMessage);
            yield break;
        }

        DataHolder.PlayerData.player = DataExtensions.SetData<Player>(request.downloadHandler.text);

        WebRequesterEventHandler.Loaded();
    }

    public IEnumerator GetAllPlayers(string url)
    {
        using UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            string errorMessage = $"Error: {request.error}\n";
            errorMessage += $"URL: {url}\n";
            errorMessage += $"Response Code: {request.responseCode}\n";
            errorMessage += $"Response: {request.downloadHandler.text}\n";
            errorMessage += $"Request Method: {request.method}\n";
            errorMessage += $"Request URL: {request.url}\n";
            errorMessage += $"Request Upload Data: {request.uploadHandler?.data.Length ?? 0} bytes\n";
            // errorMessage += $"Request Download Data: {request.downloadHandler?.data.Length ?? 0} bytes\n";
            Debug.LogError(errorMessage);
            yield break;
        }

        DataHolder.AllPlayers = DataExtensions.SetDataList<Player>(request.downloadHandler.text);

        WebRequesterEventHandler.PlayersFetched();
    }
}
