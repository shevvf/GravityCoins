using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [field: SerializeField] private List<Button> MenuButtons { get; set; }
    [field: SerializeField] private Button Close { get; set; }
    [field: SerializeField] private List<GameObject> MenuPanels { get; set; }

    private GameObject lastPanel;

    private void Start()
    {
        Close.onClick.AddListener(() => CloseMenu());

        for (int i = 0; i < MenuButtons.Count; i++)
        {
            int index = i;
            MenuButtons[i].onClick.AddListener(() => OpenPanel(index));
        }
    }

    private void OnEnable()
    {
        OpenPanel(0);
    }

    private void OpenPanel(int index)
    {
        if (lastPanel == MenuPanels[index]) return;

        if (lastPanel != null)
        {
            lastPanel.SetActive(false);
        }

        if (index >= 0 && index < MenuPanels.Count)
        {
            lastPanel = MenuPanels[index];
            lastPanel.SetActive(true);
        }
    }

    private void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
