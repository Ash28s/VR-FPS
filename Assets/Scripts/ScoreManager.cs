using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton for global access
    public TMP_Text scoreText; // UI text for displaying the score
    private int score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
