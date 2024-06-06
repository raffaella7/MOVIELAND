using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    // Array di prefab per ostacoli e monete
    public GameObject[] obstaclePrefabs;

    // Posizione di spawn
    public Transform spawnPoint;

    // Delay minimo e massimo per lo spawn
    public float minDelay = 1f;
    public float maxDelay = 3f;

    private GameManager gameManager;

    private float nextSpawnAtMeters; // tengo traccia dei metri percorsi

    private float spawnFrequency = 10f;

    private int spawnObjectNull = 6;

    void Awake()
    {
        // Trova il GameManager nella scena
        gameManager = FindObjectOfType<GameManager>();
    }


    void Start()
    {
        // StartCoroutine(SpawnRandom());
    }

    void Update()
    {
        if (-gameManager.totalMeters >= nextSpawnAtMeters) //checko se effettivamente è il momento giusto per spawnare
        {
            SpawnPrefab(obstaclePrefabs);   //spawna
            nextSpawnAtMeters += spawnFrequency;       //aggiungo 10 metri
        }
    }


    void SpawnPrefab(GameObject[] prefabs)
    {

        int spawnChance = Random.Range(0, 10);   //
        print("NUMERO NULLO");

        // Se il numero casuale è 6, non fare nulla
        if (spawnChance >= spawnObjectNull)     //se il nmero che esce è uguale a spawnobject null allora non fare niente se no spawna prefab
        {
            return;
        }




        int randomIndex = Random.Range(0, prefabs.Length);

        // spawna il prefab
        GameObject spawnedObject = Instantiate(prefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }



    // IEnumerator SpawnRandom()
    // {
    //     // loop infinito per continuare a spawnare oggetti
    //     while (true)
    //     {
    //         // casualmente mi prendo il ritardo per lo spawn
    //         float delay = Random.Range(minDelay, maxDelay);
    //         yield return new WaitForSeconds(delay);

    //         // randomicamente spawna o un ostacolo o una moneta
    //         bool spawnObstacle = Random.value > 0.5f;

    //         if (spawnObstacle && obstaclePrefabs.Length > 0)
    //         {
    //             // SPAWNA un ostacolo
    //             SpawnPrefab(obstaclePrefabs);
    //         }
    //     }
    // }

}