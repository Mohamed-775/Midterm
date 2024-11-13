using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Color targetColor;
    public Text targetColorText;
    public int score = 0;
    public Text scoreText;
    public float timeRemaining = 60f;
    public Text timerText;
    
    public GameObject gameOverScreen; // Reference to Game Over screen UI
    public Text gameOverMessageText;  // Reference to Game Over message text

    void Start()
    {
        SetNewTargetColor();
        gameOverScreen.SetActive(false); // Ensure Game Over screen is hidden initially
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetNewTargetColor()
    {
        targetColor = Color.red;  // Example color; adjust as needed
        targetColorText.text = "Target: " + targetColor.ToString();
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = "Score: " + score.ToString();

        // Check for win or lose conditions
        if (score >= 5)
        {
            GameOver("You Win!");
        }
        else if (score <= -3)
        {
            GameOver("You Lose!");
        }
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timeRemaining);
        }
        else
        {
            GameOver("Time's Up!");  // Optional, if you want to end the game when time runs out
        }
    }

    void GameOver(string message)
    {
        gameOverScreen.SetActive(true);     // Show Game Over screen
        gameOverMessageText.text = message; // Display win/lose message
        Time.timeScale = 0;                 // Pause the game
    }

    public void RestartGame()
{
    Time.timeScale = 1;           // Unpause the game
    score = 0;                    // Reset score
    scoreText.text = "Score: 0";  // Update score UI
    timeRemaining = 60f;          // Reset timer
    gameOverScreen.SetActive(false); // Hide Game Over screen
    SetNewTargetColor();          // Set a new target color
}

}
