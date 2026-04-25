using UnityEngine;
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

    public void GameOver(float score)
    {
        if (isGameOver) return;

        isGameOver = true;

        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + Mathf.FloorToInt(score);

        Time.timeScale = 0f;
    }
}