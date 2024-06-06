using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI ScoreText;
    GameManager gameManager;
    PlayerBehaivor playerBehaivor;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerBehaivor = FindObjectOfType<PlayerBehaivor>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("coin"))
        {
            gameManager.isGameOver = true;
            gameOverUI.SetActive(true);
            ScoreText.text = $"M: {Mathf.Round(Mathf.Abs(gameManager.totalMeters))}";
            playerBehaivor.CanSwipe = false;

        }
    }
}
