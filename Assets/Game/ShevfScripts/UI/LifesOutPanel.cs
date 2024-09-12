using System.Runtime.InteropServices;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class LifesOutPanel : MonoBehaviour
{
    [field: SerializeField] private Button AddLifes { get; set; }
    [field: SerializeField] private Button GetLife { get; set; }
    [field: SerializeField] private TMP_Text TimerText { get; set; }
    [field: SerializeField] private TimerManager TimerManager { get; set; }
    [field: SerializeField] private Lifes Lifes { get; set; }
    [field: SerializeField] private SaveLoad SaveLoad { get; set; }

    [DllImport("__Internal")]
    private static extern void inviteFriends(string joinUrl);

    private void Start()
    {
        TimerManager.Inizialize();
        AddLifes.onClick.AddListener(OnAddLifes);
        GetLife.onClick.AddListener(OnGetLife);

        TimerManager.OnTimerChanged += UpdateTimerText;
        TimerManager.OnTimerFinished += TimerFinished;
        Lifes.OnCurrentLifesChanged += LifesAdded;
    }

    private void OnDestroy()
    {
        TimerManager.OnTimerChanged -= UpdateTimerText;
        TimerManager.OnTimerFinished -= TimerFinished;
        Lifes.OnCurrentLifesChanged -= LifesAdded;
    }

    private void UpdateTimerText(string timeString)
    {
        TimerText.SetText(timeString);
    }

    private void TimerFinished()
    {
        TimerText.SetText("Get free life");
        GetLife.interactable = true;
    }

    private void OnGetLife()
    {
        Lifes.AddLifes();
        SaveLoad.Save();
        GetLife.interactable = false;
    }

    private void LifesAdded(int a)
    {
        DeactivatePanel();
    }

    private void DeactivatePanel()
    {
        gameObject.SetActive(false);
    }

    private void OnAddLifes()
    {
        string userId = DataHolder.PlayerData.player.userid.ToString();
        string joinUrl = string.Format("https://t.me/GravityCoin_Bot/GravityCoin?startapp={0}", userId);
        // Debug.Log(joinUrl);

        if (Application.isEditor)
        {
            Lifes.AdditionalLifes++;
            Lifes.AddLifes();
        }
        else
        {
            inviteFriends(joinUrl);
        }
    }
}
