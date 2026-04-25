using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(float score)
    {
        if (isGameOver) return;

        isGameOver = true;

        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + Mathf.FloorToInt(score);

        Time.timeScale = 0f;
    }
}