using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvObjectSpawn : MonoBehaviour
{
    GameManager gameManager;

    void Awake()
    {
        gameManager=FindAnyObjectByType<GameManager>();
    }


    void Update()
    {
        
    }
}
