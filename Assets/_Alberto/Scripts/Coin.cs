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

    void Update()
    {
        // Ruota la moneta
        transform.Rotate(100 * Time.deltaTime * Vector3.up);
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