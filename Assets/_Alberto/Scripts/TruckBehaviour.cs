using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TruckBehaviour : MonoBehaviour
{
    GameManager gameManager;


    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void Update()
    {
        MoveObject();
    }
    void MoveObject()
    {
        // Usa la variabile 'speed' per la velocità
        transform.Translate(gameManager.MovementDirection * Time.deltaTime * (gameManager.Speed + 5f));
    }
}
