using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Adds .text
using UnityEngine.SceneManagement; //Manages scenes

public class LogicManagerScript : MonoBehaviour
{
    public Text score;
    public int playerScore;
    public GameObject gameOverScreen;

    private void Start()
    {
        RabbitScript.rabbitEaten += addScore;
        BorderScript.borderCollision += gameOver;
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore += 1;
        score.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SnakeScript.alive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        SnakeScript.alive = false;
        gameOverScreen.SetActive(true);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event
        RabbitScript.rabbitEaten -= addScore;
        BorderScript.borderCollision -= gameOver;
    }
}
