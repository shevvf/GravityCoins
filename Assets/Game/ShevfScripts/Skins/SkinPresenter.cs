using UnityEngine;

public class SkinPresenter : MonoBehaviour
{
    [field: SerializeField] public SkinView SkinView { get; set; }
    [field: SerializeField] public SkinModel SkinModel { get; set; }
    [field: SerializeField] public CryptoCoins CryptoCoins { get; set; }

    private void Start()
    {
        InitializeModel();
        InitializeView();
    }

    private void OnDestroy()
    {
        SkinModel.OnIsUnlockedChanged -= SkinConditionChanged;
        SkinModel.OnIsSettedChanged -= UpdateButtonState;
    }

    private void InitializeModel()
    {
        SkinModel.OnIsUnlockedChanged += SkinConditionChanged;
        SkinModel.OnIsSettedChanged += UpdateButtonState;
    }

    private void InitializeView()
    {
        SkinView.ActionButton.onClick.AddListener(ButtonAction);

        SkinView.SkinImage.sprite = SkinModel.SkinConfig.SkinSprite;
        SkinPriceView(SkinModel.IsUnlocked);
        UpdateButtonState();
    }

    private void SkinPriceView(bool isUnlocked)
    {
        SkinView.SkinPrice.gameObject.SetActive(!isUnlocked);

        if (isUnlocked) return;
        SkinView.SkinPrice.SetText(SkinModel.SkinConfig.SkinPrice.ToString());
    }

    private void UpdateButtonState()
    {
        if (SkinModel.IsUnlocked)
        {
            if (SkinModel.IsSetted)
            {
                SkinView.ActionButtonText.SetText("Setted");
            }
            else
            {
                SkinView.ActionButtonText.SetText("Set");
            }
        }
        else
        {
            SkinView.ActionButtonText.SetText("Unlock");
        }
    }

    private void ButtonAction()
    {
        if (!SkinModel.IsUnlocked)
        {
            int coins = CryptoCoins.CryptoCoinsValue;
            if (Application.isEditor)
            {
                coins += 100;
            }

            if (coins >= SkinModel.SkinConfig.SkinPrice)
            {
                CryptoCoins.CryptoCoinsValue -= SkinModel.SkinConfig.SkinPrice;
                SkinModel.IsUnlocked = true;
            }
            else
            {
                Debug.Log("Not enough coins!");
            }
        }
        else
        {
            SetSkin();
        }

        UpdateButtonState();
    }

    private void SetSkin()
    {
        foreach (var otherSkin in FindObjectsOfType<SkinPresenter>())
        {
            if (otherSkin != this && otherSkin.SkinModel.IsSetted)
            {
                otherSkin.SkinModel.IsSetted = false;
            }
        }

        SkinModel.IsSetted = true;

        SpriteRenderer playerSpriteRenderer = FindAnyObjectByType<BikeController>().GetComponent<SpriteRenderer>();
        playerSpriteRenderer.sprite = SkinModel.SkinConfig.SkinSprite;

        UpdateButtonState();
    }

    private void SkinConditionChanged(bool isUnlocked)
    {
        SkinPriceView(isUnlocked);
        UpdateButtonState();
    }
}
