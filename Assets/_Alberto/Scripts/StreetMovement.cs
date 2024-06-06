using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMovement : MonoBehaviour
{
    private float MaxPosition = -17.4f;
    private float Progress;
    GameManager gameManager;

    private Vector3 StartPosition;
    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        StartPosition = transform.position;
    }

    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.Translate(gameManager.MovementDirection * Time.deltaTime * gameManager.Speed);
        Progress += gameManager.MovementDirection.z * Time.deltaTime * gameManager.Speed;
        gameManager.totalMeters += gameManager.MovementDirection.z * Time.deltaTime * gameManager.Speed;
        // print(Progress);
        // print(gameManager.totalMeters);
        if (Progress <= MaxPosition)
        {
            transform.position = StartPosition;
            Progress = 0;
        }
    }
}
