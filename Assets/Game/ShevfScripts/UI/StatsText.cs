using Game.ShevfScripts;

using TMPro;

using UnityEngine;

public class StatsText : MonoBehaviour
{
    [field: SerializeField] private TMP_Text CryptoCoinsText { get; set; }
    [field: SerializeField] private TMP_Text LifesText { get; set; }
    [field: SerializeField] private CryptoCoins CryptoCoins { get; set; }
    [field: SerializeField] private Lifes Lifes { get; set; }
    [field: SerializeField] private WebRequesterEventHandler WebRequesterEventHandler { get; set; }

    private void Start()
    {
        WebRequesterEventHandler.OnLoaded += DataLoaded;

        CryptoCoins.OnCoinsValueChanged += UpdateCryptoCoinsText;
        Lifes.OnCurrentLifesChanged += UpdateLifesText;
    }

    private void OnDestroy()
    {
        WebRequesterEventHandler.OnLoaded -= DataLoaded;

        CryptoCoins.OnCoinsValueChanged -= UpdateCryptoCoinsText;
        Lifes.OnCurrentLifesChanged -= UpdateLifesText;
    }

    private void DataLoaded()
    {
        UpdateCryptoCoinsText(CryptoCoins.CryptoCoinsValue);
        UpdateLifesText(Lifes.CurrentLifes);
    }

    private void UpdateCryptoCoinsText(int newCoins)
    {
        CryptoCoinsText.SetText(newCoins.ToString());
    }

    private void UpdateLifesText(int newLifes)
    {
        LifesText.SetText(newLifes.ToString());
    }
}
