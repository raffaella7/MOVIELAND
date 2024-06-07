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
        transform.Translate(gameManager.MovementDirection * Time.deltaTime * gameManager.Speed, Space.World);
    }
}
