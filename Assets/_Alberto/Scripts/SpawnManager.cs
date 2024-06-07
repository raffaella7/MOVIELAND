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
    private float CoinnextSpawnAtMeters = 5; // tengo traccia dei metri percorsi

    private float spawnFrequency = 15f;
    private float CoinspawnFrequency = 6f;

    private int spawnObjectNull = 7;
    private float delay = 10f;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    List<float> spawnPoints = new List<float>() { -1.4f, 0, 1.4f };
    int RandIndex;
    int lastRandIndex;
    int[] obstacleLanes;

    void Start()
    {
        RandIndex = Random.Range(0, spawnPoints.Count);
    }

    void Awake()
    {
        // Trova il GameManager nella scena
        gameManager = FindObjectOfType<GameManager>();
        // StartCoroutine(RandomizeLaneCoin());

    }

    void Update()
    {
        if (obstacleLanes != null)
            RandIndex = System.Array.FindIndex(obstacleLanes, lane => lane == 0);
        if (-gameManager.totalMeters > nextSpawnAtMeters) //checko se effettivamente è il momento giusto per spawnare
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

    void SpawnCoin()
    {
        GameObject spawnedObject = Instantiate(coinPrefab, new Vector3(spawnPoints[RandIndex], .5f, CarPrefab.transform.GetChild(0).transform.position.z + 25), coinPrefab.transform.rotation);
        spawnedObjects.Add(spawnedObject);
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

        spawnedObjects.Add(spawnedObject);
        obstacleLanes = spawnedObject.GetComponent<ObstacleLaneInfo>().lanes;
        // print($"{RandIndex} - {obstacleLanes[0]} {obstacleLanes[1]} {obstacleLanes[2]}");


    }


    public void DestroyAllSapwnedObjects()
    {
        foreach (GameObject shibino in spawnedObjects)
        {
            if (shibino != null)
            {
                Destroy(shibino);
            }
        };
        //devo ripulire tutta la lista
        spawnedObjects.Clear();
        nextSpawnAtMeters = 0;
        CoinnextSpawnAtMeters = 5;
    }
}