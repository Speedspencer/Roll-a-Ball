using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float gameTime = 60.0f;  // Time in seconds for the game to last
    [SerializeField] private float timeRemaining;    // Time remaining in the game
    private bool gameRunning = false;
    public TMP_Text timerText;
    public PlayerController playerController;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        StartGame();
    }

    void Update()
    {
        if (gameRunning)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time remaining: " + timeRemaining.ToString("F2");
            if (timeRemaining <= 0.0f)
            {
                EndGame();
            }
        }
    }

    public void StartGame()
    {
        gameRunning = true;
        timeRemaining = gameTime;
    }

    public void EndGame()
    {
        gameRunning = false;
        Debug.Log("Game over!");
        StartGame();
        playerController.Restart();
    }
}
