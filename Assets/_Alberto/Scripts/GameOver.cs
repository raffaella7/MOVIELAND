using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI textCoins;
    GameManager gameManager;
    PlayerBehaivor playerBehaivor;
    InputManager inputManager;

    void Awake()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        gameManager = FindObjectOfType<GameManager>();
        playerBehaivor = FindObjectOfType<PlayerBehaivor>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("coin"))
        {
            gameManager.isGameOver = true;
            gameOverUI.SetActive(true);
            ScoreText.text = $"Meters: {Mathf.Round(Mathf.Abs(gameManager.totalMeters))}";
            textCoins.text = $"Coins: {gameManager.coinCount}";
            playerBehaivor.CanSwipe = false;
            inputManager.gameObject.SetActive(false);
        }
    }

}
