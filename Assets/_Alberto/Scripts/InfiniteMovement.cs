using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMovement : MonoBehaviour
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
        transform.Translate(gameManager.MovementDirection * Time.deltaTime * gameManager.Speed, Space.World);
    }
}
