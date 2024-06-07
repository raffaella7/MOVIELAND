using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour

{
    GameManager gameManager;
    public TextMeshProUGUI coinText; // Riferimento al Text della UI

    public TextMeshProUGUI textMeters;

    public GameObject gameOverUI;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        MetersUI();
        UIAddCoin();
    }
    public void MetersUI()
    {
        textMeters.text = $"Meters: {Mathf.Round(Mathf.Abs(gameManager.totalMeters))}";
    }
    public void UIAddCoin()
    {
        coinText.text = "Coins: " + gameManager.coinCount;
    }

}

