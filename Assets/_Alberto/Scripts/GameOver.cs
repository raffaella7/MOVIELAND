using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI ScoreText;
    GameManager gameManager;
    void OnCollisionEnter(Collision collision)
    {
        gameManager.Speed = 0;
        gameOverUI.SetActive(true);
    }
}
