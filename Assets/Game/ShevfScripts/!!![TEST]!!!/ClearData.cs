using UnityEngine;
using UnityEngine.UI;

public class ClearData : MonoBehaviour
{
    [field: SerializeField] private Button Button { get; set; }

    private void Start()
    {
        Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
