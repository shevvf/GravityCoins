using TMPro;

using UnityEngine;

public class CryptoCoinsCollector : MonoBehaviour
{
    [field: SerializeField] private TMP_Text RuntimeCryptoCoinsText { get; set; }
    [field: SerializeField] private SaveLoad SaveLoad { get; set; }
    [field: SerializeField] private CryptoCoins CryptoCoins { get; set; }

    private void Start()
    {
        CryptoCoins.OnCoinsRuntimeChanged += UpdateScoreText;
    }

    private void OnDestroy()
    {
        CryptoCoins.OnCoinsRuntimeChanged -= UpdateScoreText;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            CryptoCoins.CryptoCoinsRuntime += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Claim"))
        {
            CryptoCoins.CryptoCoinsValue += CryptoCoins.CryptoCoinsRuntime;
            CryptoCoins.CryptoCoinsRuntime = 0;
            SaveLoad.Save();
        }
    }

    private void UpdateScoreText(int newCoins)
    {
        RuntimeCryptoCoinsText.SetText(newCoins.ToString());
    }
}
