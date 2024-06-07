using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartUI;
    public GameObject GameUI;
    public Vector3 MovementDirection = new Vector3(0, 0, -1);
    public float Speed = 10;
    public bool isGameOver;
    private float increasingSpeed = 0.5f;
    public float totalMeters;
    public bool isGameStarted;

    void Update()
    {
        IncreaseSpeed();
    }

    private void IncreaseSpeed()
    {
        if (!isGameOver && isGameStarted)
        {
            StartUI.SetActive(false);
            GameUI.SetActive(true);
            Speed += increasingSpeed * Time.deltaTime;
        }
        else if (isGameOver)
        {
            GameUI.SetActive(false);
            Speed = 0;
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene("ScanQR");
    }
    public void TapToPlay()
    {
        isGameStarted = true;
    }

}
