using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GameState
{
    Waiting,
    Playing,
    GameOver,
    LAST
}

public class GameController : MonoBehaviour
{
    public static GameState currentGameStatus;

    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;

    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private float sliderCurrentFillAmount = 1f;

    private int playerScore;

    private void Awake()
    {
        currentGameStatus = GameState.Waiting;
    }

    private void Update()
    {
        if (currentGameStatus == GameState.Playing)
            AdjustTimer();
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);

        sliderCurrentFillAmount = timerImage.fillAmount;
    }

    public void UpdatePlayerScore(int asteroidHitPoints)
    {
        if (currentGameStatus != GameState.Playing)
            return;


        playerScore += asteroidHitPoints;
        scoreText.text = playerScore.ToString();
    }
}
