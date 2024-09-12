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

    // Метод для начала игры
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Замена "GameScene" на имя вашей игровой сцены
    }

    // Метод для открытия панели настроек
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        shopPanel.SetActive(false);
        referralPanel.SetActive(false);
    }

    // Метод для открытия панели лидерборда
    public void OpenLeaderboard()
    {
        settingsPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
        shopPanel.SetActive(false);
        referralPanel.SetActive(false);
    }

    // Метод для открытия панели выбора скина (магазин)
    public void OpenShop()
    {
        settingsPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        shopPanel.SetActive(true);
        referralPanel.SetActive(false);
    }

    // Метод для открытия панели реферальной системы
    public void OpenReferral()
    {
        settingsPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        shopPanel.SetActive(false);
        referralPanel.SetActive(true);
    }

    // Метод для закрытия панели
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    // Метод для выхода из игры
    public void QuitGame()
    {
        Application.Quit();
    }
}
