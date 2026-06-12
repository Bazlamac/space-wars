using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SCOREMAN : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score = 0;


    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public AudioSource backgroundMusic;

    void Start()
    {
        UpdateScoreDisplay();

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
    }



    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;

            if (finalScoreText != null)
            {
                finalScoreText.text = "Final Score: " + score.ToString();
            }

           
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");

    }

    public void ToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}