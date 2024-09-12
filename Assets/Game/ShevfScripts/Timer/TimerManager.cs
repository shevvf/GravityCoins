using System;
using System.Collections;

using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private const int TIMER_DURATION_SECONDS = 15;  //Release value 21600 (6 hours)

    [field: SerializeField] private Timer Timer { get; set; }
    private float RemainingTime { get; set; }

    public Action<string> OnTimerChanged { get; set; }
    public Action OnTimerFinished { get; set; }

    public void Inizialize()
    {
        StartCoroutine(Timer.GetServerTime(OnServerTimeReceived));
    }

    private void OnServerTimeReceived(DateTime serverTime)
    {
        string lastDeath = DataHolder.PlayerData.player.lifetimer;
        if (!string.IsNullOrEmpty(lastDeath))
        {
            DateTime lastDeathTime = DateTime.Parse(lastDeath);
            TimeSpan timePassed = serverTime - lastDeathTime;

            RemainingTime = Mathf.Max(0, TIMER_DURATION_SECONDS - (float)timePassed.TotalSeconds);

            Debug.Log("lastDeathTime " + lastDeathTime);
            Debug.Log("serverTime " + serverTime);
        }
        else
        {
            RemainingTime = TIMER_DURATION_SECONDS;
        }

        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;
            OnTimerChanged?.Invoke(GetFormattedTime());
            yield return null;
        }

        TimerFinished();
    }

    private string GetFormattedTime()
    {
        int hours = Mathf.FloorToInt(RemainingTime / 3600);
        int minutes = Mathf.FloorToInt((RemainingTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(RemainingTime % 60);

        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    private void TimerFinished()
    {
        OnTimerFinished?.Invoke();
    }
}
