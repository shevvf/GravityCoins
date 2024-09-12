using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject leaderboardPanel;
    [SerializeField]
    private GameObject shopPanel;
    [SerializeField]
    private GameObject referralPanel;

    // ����� ��� ������ ����
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // ������ "GameScene" �� ��� ����� ������� �����
    }

    // ����� ��� �������� ������ ��������
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        shopPanel.SetActive(false);
        referralPanel.SetActive(false);
    }

    // ����� ��� �������� ������ ����������
    public void OpenLeaderboard()
    {
        settingsPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
        shopPanel.SetActive(false);
        referralPanel.SetActive(false);
    }

    // ����� ��� �������� ������ ������ ����� (�������)
    public void OpenShop()
    {
        settingsPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        shopPanel.SetActive(true);
        referralPanel.SetActive(false);
    }

    // ����� ��� �������� ������ ����������� �������
    public void OpenReferral()
    {
        settingsPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        shopPanel.SetActive(false);
        referralPanel.SetActive(true);
    }

    // ����� ��� �������� ������
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    // ����� ��� ������ �� ����
    public void QuitGame()
    {
        Application.Quit();
    }
}
