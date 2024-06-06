using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    // Array di prefab per ostacoli e monete
    public GameObject[] obstaclePrefabs;
    public GameObject[] coinPrefabs;

    // Posizione di spawn
    public Transform spawnPoint;

    // Delay minimo e massimo per lo spawn
    public float minDelay = 1f;
    public float maxDelay = 3f;


    public float objectLifetime = 5f;   //tempo per distruggere gli oggetti spawnati

    void Start()
    {

        StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        // loop infinito per continuare a spawnare oggetti
        while (true)
        {
            // casualmente mi prendo il ritardo per lo spawn
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // randomicamente spawna o un ostacolo o una moneta
            bool spawnObstacle = Random.value > 0.5f;

            if (spawnObstacle && obstaclePrefabs.Length > 0)
            {
                // SPAWNA un ostacolo
                SpawnPrefab(obstaclePrefabs);
            }
            else if (coinPrefabs.Length > 0)
            {
                // spawna monete
                int numCoins = Random.Range(3, 6); // Da 3 a 5 monete
                for (int i = 0; i < numCoins; i++)
                {
                    SpawnPrefab(coinPrefabs);
                }
            }
        }
    }

    void SpawnPrefab(GameObject[] prefabs)
    {
        // prendo casualmente un prefab dall'array
        int randomIndex = Random.Range(0, prefabs.Length);

        // spawna il prefab
        GameObject spawnedObject = Instantiate(prefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);

        // distruggo l'oggetto dopo un tot
        Destroy(spawnedObject, objectLifetime);
    }
}