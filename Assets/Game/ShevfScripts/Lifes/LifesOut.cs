using System;
using System.Collections;

using Game.ShevfScripts;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LifesOut : MonoBehaviour
{
    [field: SerializeField] private GameObject LifesOutPanel { get; set; }
    [field: SerializeField] private Lifes Lifes { get; set; }
    [field: SerializeField] private BikeDriver BikeDriver { get; set; }
    [field: SerializeField] private SaveLoad SaveLoad { get; set; }
    [field: SerializeField] private Timer Timer { get; set; }
    [field: SerializeField] private WebRequesterEventHandler WebRequesterEventHandler { get; set; }

    private void Start()
    {
        WebRequesterEventHandler.OnLoaded += DataLoaded;
        BikeDriver.OnDie += DecreaseLife;
    }

    private void OnDestroy()
    {
        WebRequesterEventHandler.OnLoaded -= DataLoaded;
        BikeDriver.OnDie -= DecreaseLife;
    }

    private void DataLoaded()
    {
        if (Lifes.CurrentLifes <= 0)
        {
            ActivatePanel();
        }
    }

    private void DecreaseLife()
    {
        Lifes.CurrentLifes--;
        if (Lifes.CurrentLifes == 0)
        {
            StartCoroutine(WaitForServerTimeAndLoadScene());
        }
        else
        {
            SaveLoad.Save();
            SceneManager.LoadSceneAsync(0);
        }
    }

    private IEnumerator WaitForServerTimeAndLoadScene()
    {
        yield return StartCoroutine(Timer.GetServerTime(SetTimeOfDeath));

        SaveLoad.Save();
        SceneManager.LoadSceneAsync(0);
    }

    private void SetTimeOfDeath(DateTime serverTime)
    {
        DataHolder.PlayerData.player.lifetimer = serverTime.ToString();
    }

    private void ActivatePanel()
    {
        LifesOutPanel.SetActive(true);
    }
}
