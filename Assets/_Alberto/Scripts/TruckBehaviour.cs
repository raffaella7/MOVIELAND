using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TruckBehaviour : MonoBehaviour
{
    GameManager gameManager;
    private float speed = 15f;


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
        speed += gameManager.increasingSpeed * Time.deltaTime;
        // Usa la variabile 'speed' per la velocità
        transform.Translate(gameManager.MovementDirection * Time.deltaTime * speed);
    }
}
