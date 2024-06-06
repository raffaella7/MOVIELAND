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

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        gameManager.isGameOver = true;
        gameOverUI.SetActive(true);
        ScoreText.text = $"M: {Mathf.Round(Mathf.Abs(gameManager.totalMeters))}";
    }
}
