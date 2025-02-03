using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TMP_Text timerText; // UI text for displaying the timer
    public TMP_Text scoreText; // UI text for displaying the score in the end screen
    public GameObject scoreCanvas; // Canvas to display the score

    public GameObject Canvas1;

    public float gameDuration = 180f; // 3 minutes in seconds

    private float remainingTime;
    private bool isGameOver = false;

    void Start()
    {
        remainingTime = gameDuration;
        scoreCanvas.SetActive(false); // Ensure the score canvas is initially inactive
    }

    void Update()
    {
        if (isGameOver) return;

        // Decrease remaining time
        remainingTime -= Time.deltaTime;

        // Update UI
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = $"{minutes:0}:{seconds:00}";

        // Check if time is up
        if (remainingTime <= 0f)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        timerText.text = "0:00";

        // Display the final score
        int finalScore = ScoreManager.Instance.GetScore();
        scoreCanvas.SetActive(true); // Activate the canvas
        Canvas1.SetActive(false);
        scoreText.text = $"{finalScore}";

        // Transition to the end scene after 2 seconds
        Invoke("LoadEndScene", 5f);
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene"); // Replace with your scene name
    }
}
