using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 MovementDirection = new Vector3(0, 0, -1);
    public float Speed = 10;
    public bool isGameOver;
    private float increasingSpeed = 0.5f;
    public float totalMeters;

    void Update()
    {
        IncreaseDifficulty();
    }

    private void IncreaseDifficulty()
    {
        if (!isGameOver)
            Speed += increasingSpeed * Time.deltaTime;
        else if (isGameOver)
        {
            Speed = 0;
        }
    }

}
