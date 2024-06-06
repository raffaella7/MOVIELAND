using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour

{
    private UIManager uIManager;

    private void Start()
    {
        // Trova il CoinManager nella scena
        uIManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assicurati che il player abbia il tag "Player"
        {
            uIManager.AddCoin(); // Aggiungi una moneta al punteggio
            Destroy(gameObject); // Distruggi la moneta
        }
    }
}