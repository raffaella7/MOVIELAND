using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Vector3 MovementDirection = new Vector3(0, 0, -1);
    [HideInInspector] public float Speed = 10;
    [HideInInspector] public bool isGameOver;
    [HideInInspector] public float totalMeters;
    [HideInInspector] public bool isGameStarted;
    public GameObject StartUI;
    public GameObject GameUI;
    public GameObject gameOverUI;
    InputManager inputManager;
    PlayerBehaivor playerBehaivor;
    private float increasingSpeed = 0.2f;
    SpawnManager spawnManager;
    void Awake()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        inputManager = FindObjectOfType<InputManager>();
        playerBehaivor = FindObjectOfType<PlayerBehaivor>();
    }

    void Update()
    {
        IncreaseSpeed();
        print(Speed);
    }

    private void IncreaseSpeed()
    {
        if (!isGameOver && isGameStarted)
        {
            StartUI.SetActive(false);
            GameUI.SetActive(true);
            Speed += increasingSpeed * Time.deltaTime;
            Speed = Mathf.Clamp(Speed, 0, 20);
        }
        else if (isGameOver)
        {
            GameUI.SetActive(false);
            Speed = 0;
        }
    }
    //da fixare 
    public void Respawn()
    {
        gameOverUI.SetActive(false);
        isGameOver = false;
        isGameStarted = true;
        inputManager.gameObject.SetActive(true);
        Speed = 10;
        playerBehaivor.OnRestart();
        totalMeters = 0;
        spawnManager.DestroyAllSapwnedObjects();
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
