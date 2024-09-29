using System;

using UnityEngine;

public class SkinModel : MonoBehaviour
{
    [field: SerializeField] public SkinConfig SkinConfig { get; private set; }

    public Action<bool> OnIsUnlockedChanged;
    public Action OnIsSettedChanged;

    private bool? isUnlocked;
    private bool? isSetted;

    public bool IsUnlocked
    {
        get
        {
            if (!isUnlocked.HasValue)
            {
                isUnlocked = SkinConfig.IsUnlocked;
            }
            return isUnlocked.Value;
        }
        set
        {
            if (isUnlocked != value)
            {
                isUnlocked = value;
                OnIsUnlockedChanged?.Invoke(isUnlocked.Value);
            }
        }
    }

    public bool IsSetted
    {
        get
        {
            if (!isSetted.HasValue)
            {
                isSetted = SkinConfig.IsSetted;
            }
            return isSetted.Value;
        }
        set
        {
            if (isSetted != value)
            {
                isSetted = value;
                OnIsSettedChanged?.Invoke();
            }
        }
    }
}
