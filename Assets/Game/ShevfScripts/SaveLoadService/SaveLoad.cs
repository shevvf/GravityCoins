using System;

using UnityEngine;

public class SaveLoad : MonoBehaviour, ISaveLoad
{
    public Action OnSave { get; set; }
    public Action OnLoad { get; set; }

    public void Save() => OnSave?.Invoke();
    public void Load() => OnLoad?.Invoke();
}
