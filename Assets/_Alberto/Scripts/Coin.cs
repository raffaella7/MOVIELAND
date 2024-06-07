using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour

{
    private GameManager gameManager;

    private void Start()
    {
        // Trova il CoinManager nella scena
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assicurati che il player abbia il tag "Player"
        {
            gameManager.AddCoin(); // Aggiungi una moneta al punteggio
            Destroy(gameObject); // Distruggi la moneta
        }
    }
}