using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class SkinView : MonoBehaviour
{
    [field: SerializeField] public Image SkinImage { get; private set; }
    [field: SerializeField] public TMP_Text SkinPrice { get; private set; }
    [field: SerializeField] public Button ActionButton { get; private set; }
    [field: SerializeField] public TMP_Text ActionButtonText { get; private set; }
}
