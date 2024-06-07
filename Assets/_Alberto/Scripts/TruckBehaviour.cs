using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TruckBehaviour : MonoBehaviour
{
    GameManager gameManager;
    private float speedTruck = 10f;

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
        transform.Translate(gameManager.MovementDirection * Time.deltaTime * (gameManager.Speed + speedTruck));
    }

    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.GetComponent<InfiniteMovement>())
        {
            speedTruck = 0;
        }
    }
}
