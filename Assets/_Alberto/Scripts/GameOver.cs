using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    GameManager gameManager;
    PlayerBehaivor playerBehaivor;
    InputManager inputManager;
    UIManager uIManager;
    TruckBehaviour truckBehaviour;

    void Awake()
    {
        uIManager = FindAnyObjectByType<UIManager>();
        truckBehaviour = FindAnyObjectByType<TruckBehaviour>();
        inputManager = FindAnyObjectByType<InputManager>();
        gameManager = FindObjectOfType<GameManager>();
        playerBehaivor = FindObjectOfType<PlayerBehaivor>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("coin"))
        {
            uIManager.GameOver();
            gameManager.isGameOver = true;
            // textCoins.text = $"Coins: {gameManager.coinCount}";
            playerBehaivor.CanSwipe = false;
            inputManager.gameObject.SetActive(false);
            truckBehaviour.speedTruck = 0;
        }
    }

}
