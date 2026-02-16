using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 5;
    private int score = 0;

    // Method to reduce lives when an enemy reaches the end of the path
    public void LoseLife()
    {
        lives -= 1;
        Debug.Log("Life lost! Remaining lives: " + lives);
    }

    // Method to increase score when an enemy is defeated
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score increased! Current score: " + score);
    }
}
