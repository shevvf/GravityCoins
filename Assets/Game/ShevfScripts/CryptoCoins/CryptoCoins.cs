using System;

using UnityEngine;

public class CryptoCoins : MonoBehaviour
{
    private int cryptoCoinsValue;
    private int cryptoCoinsRuntime;
    public Action<int> OnCoinsValueChanged { get; set; }
    public Action<int> OnCoinsRuntimeChanged { get; set; }

    public int CryptoCoinsValue
    {
        get
        {
            if (cryptoCoinsValue == 0)
            {
                return DataHolder.PlayerData.player.coin;
            }
            return cryptoCoinsValue;
        }
        set
        {
            if (cryptoCoinsValue != value)
            {
                cryptoCoinsValue = value;
                DataHolder.PlayerData.player.coin = value;
                OnCoinsValueChanged?.Invoke(cryptoCoinsValue);
            }
        }
    }

    public int CryptoCoinsRuntime
    {
        get
        {
            return cryptoCoinsRuntime;
        }
        set
        {
            if (cryptoCoinsRuntime != value)
            {
                cryptoCoinsRuntime = value;
                OnCoinsRuntimeChanged?.Invoke(cryptoCoinsRuntime);
            }
        }
    }
}