using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    // Array di prefab per ostacoli e monete
    public GameObject[] obstaclePrefabs;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject CarPrefab;

    // Posizione di spawn
    public Transform spawnPoint;

    // Delay minimo e massimo per lo spawn
    public float minDelay = 1f;
    public float maxDelay = 3f;

    private GameManager gameManager;

    private float nextSpawnAtMeters; // tengo traccia dei metri percorsi
    private float CoinnextSpawnAtMeters; // tengo traccia dei metri percorsi

    private float spawnFrequency = 15f;
    private float CoinspawnFrequency = 4f;

    private int spawnObjectNull = 6;
    List<float> spawnPoints = new List<float>() { -1.4f, 0, 1.4f };
    int RandIndex;
    int lastRandIndex;

    void Awake()
    {
        // Trova il GameManager nella scena
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(RandomizeLaneCoin());

    }


    void Start()
    {


    }

    void Update()
    {
        if (-gameManager.totalMeters >= nextSpawnAtMeters) //checko se effettivamente è il momento giusto per spawnare
        {
            SpawnPrefab(obstaclePrefabs);   //spawna
            nextSpawnAtMeters += spawnFrequency;       //aggiungo 10 metri

        }
        if (-gameManager.totalMeters >= CoinnextSpawnAtMeters) //checko se effettivamente è il momento giusto per spawnare
        {
            SpawnCoin();   //spawna
            CoinnextSpawnAtMeters += CoinspawnFrequency;       //aggiungo 10 metri

        }


    }

    IEnumerator RandomizeLaneCoin()
    {
        yield return new WaitForSeconds(2f);
        RandIndex = Random.Range(0, spawnPoints.Count);
        while (RandIndex == lastRandIndex)
        {
            RandIndex = Random.Range(0, spawnPoints.Count);
        }
        lastRandIndex = RandIndex;
        StartCoroutine(RandomizeLaneCoin());
    }

    void SpawnCoin()
    {
        Instantiate(coinPrefab, new Vector3(spawnPoints[RandIndex], 0, CarPrefab.transform.GetChild(0).transform.position.z + 8), spawnPoint.rotation);
    }

    void SpawnPrefab(GameObject[] prefabs)
    {

        int spawnChance = Random.Range(0, 10);   //
        // print("NUMERO NULLO");

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