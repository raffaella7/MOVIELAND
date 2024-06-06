using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour

{
    public TextMeshProUGUI coinText; // Riferimento al Text della UI
    private int coinCount = 0; // Conteggio delle monete

    // Metodo per aggiornare il punteggio
    public void AddCoin()
    {
        coinCount++;
        coinText.text = "Coins: " + coinCount;
    }
}

