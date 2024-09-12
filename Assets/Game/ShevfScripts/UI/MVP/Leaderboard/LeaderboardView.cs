using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [field: SerializeField] public Transform LeaderboardContent { get; private set; }
    [field: SerializeField] public GameObject LeaderboardElement { get; private set; }
}
