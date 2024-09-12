using System;

using UnityEngine;

public class Lifes : MonoBehaviour
{
    private int lifesValue = -1;
    private int currentLifes = -1;
    private int additionalLifes = 0;

    public Action<int> OnCurrentLifesChanged { get; set; }
    public Action OnCurrentLifesZero { get; set; }


    public int LifesValue
    {
        get
        {
            if (lifesValue == -1)
            {
                return DataHolder.PlayerData.player.lifes + DataHolder.PlayerData.player.additionallifes;
            }
            return lifesValue;
        }
    }

    public int CurrentLifes
    {
        get
        {
            if (currentLifes == -1)
            {
                return DataHolder.PlayerData.player.lifes;
            }
            return currentLifes;
        }
        set
        {
            if (currentLifes != value)
            {
                currentLifes = value;
                DataHolder.PlayerData.player.lifes = value;
                OnCurrentLifesChanged?.Invoke(currentLifes);
                if (currentLifes == 0)
                {
                    OnCurrentLifesZero?.Invoke();
                }
            }
        }
    }

    public int AdditionalLifes
    {
        get
        {
            if (additionalLifes == 0)
            {
                return DataHolder.PlayerData.player.additionallifes;
            }
            return additionalLifes;
        }
        set
        {
            if (additionalLifes != value)
            {
                additionalLifes = value;
                DataHolder.PlayerData.player.additionallifes = value;
            }
        }
    }

    public void AddLifes()
    {
        CurrentLifes = LifesSettings.DEFAULT_LIFES + AdditionalLifes;
    }
}
