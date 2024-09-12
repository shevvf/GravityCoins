using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

public class Timer : MonoBehaviour
{
    public IEnumerator GetServerTime(Action<DateTime> callback)
    {
        using UnityWebRequest request = UnityWebRequest.Get(WebRequestSettings.WORLD_TIME_API_URL);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }

        var worldTime = JsonUtility.FromJson<WorldTimeApiResponse>(request.downloadHandler.text);
        DateTime serverTime = DateTime.Parse(worldTime.datetime);
        callback?.Invoke(serverTime);
    }
}
