using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 5;

    // Method to reduce lives when an enemy reaches the end of the path
    public void LoseLife()
    {
        lives -= 1;
        Debug.Log("Life lost! Remaining lives: " + lives);
    }
}
