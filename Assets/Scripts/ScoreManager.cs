using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private float score;
    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best: " + highScore;
    }

    void Update()
    {
        UpdateScore();
        CheckHighScore();
    }

    void UpdateScore()
    {
        score = player.position.z;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = Mathf.FloorToInt(score);
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "Best: " + highScore;
        }
    }
}