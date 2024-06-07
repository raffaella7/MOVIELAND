using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour

{
    GameManager gameManager;
    public TextMeshProUGUI coinText; // Riferimento al Text della UI
    private int coinCount = 0; // Conteggio delle monete
    public TextMeshProUGUI textMeters;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        MetersUI();
    }
    public void MetersUI()
    {
        textMeters.text = $"Meters: {Mathf.Round(Mathf.Abs(gameManager.totalMeters))}";
    }
    public void AddCoin()
    {
        coinCount++;
        coinText.text = "Coins: " + coinCount;
    }

}

