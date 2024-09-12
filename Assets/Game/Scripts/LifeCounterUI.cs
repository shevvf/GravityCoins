using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCounterUI : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    [SerializeField] private Text livesText;

    private void Start()
    {
        currentLives = maxLives;
        UpdateLivesText();
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log("Life lost! Current lives: " + currentLives);
            UpdateLivesText();

            if (currentLives <= 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагрузить текущую сцену
    }

    public void GainLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            Debug.Log("Life gained! Current lives: " + currentLives);
            UpdateLivesText();
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + currentLives;
    }
}
