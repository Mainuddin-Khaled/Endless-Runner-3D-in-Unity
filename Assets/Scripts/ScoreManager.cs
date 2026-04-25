using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    private float score;

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        score = player.position.z;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
}