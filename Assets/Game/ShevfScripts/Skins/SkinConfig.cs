using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "StaticData/" + nameof(SkinConfig))]
public class SkinConfig : ScriptableObject
{
    [field: SerializeField] public Sprite SkinSprite { get; private set; }

    [field: SerializeField] public int SkinPrice { get; private set; }

    [field: SerializeField] public bool IsUnlocked { get; private set; }

    [field: SerializeField] public bool IsSetted { get; private set; }
}
