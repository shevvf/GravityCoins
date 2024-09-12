using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class LeaderboardElementView : MonoBehaviour
{
    [field: SerializeField] public TMP_Text PlayerPlace { get; private set; }

    [field: SerializeField] public TMP_Text PlayerCoins { get; private set; }

    [field: SerializeField] public TMP_Text PlayerName { get; private set; }

    [field: SerializeField] public Image PlayerImage { get; private set; }
}
