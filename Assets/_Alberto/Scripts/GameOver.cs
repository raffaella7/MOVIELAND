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
    GameManager gameManager;
    InputManager inputManager;

    void Awake()
    {
        inputManager = FindAnyObjectByType<InputManager>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        gameManager.isGameOver = true;
        gameOverUI.SetActive(true);
        ScoreText.text = $"Meters: {Mathf.Round(Mathf.Abs(gameManager.totalMeters))}";
        inputManager.gameObject.SetActive(false);
    }
}
