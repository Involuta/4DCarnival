using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Random = System.Random;

public class SpawningEnemies : MonoBehaviour
{
    private Random r = new Random();

    public GameObject slapper;
    public GameObject unicyclist;
    private GameObject enemy;

    public LayerMask whatIsPlayer;
    public float spawnRadius;
    public bool playerInSpawnRange;

    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemiesLoop();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSpawnRange = Physics.CheckSphere(transform.position, spawnRadius, whatIsPlayer);
    }

    async void SpawnEnemiesLoop()
    {
        float startingDelayEndTime = Time.time + .5f;
        while (Time.time < startingDelayEndTime)
        {
            await Task.Yield();
        }

        while (true)
        {
            await CheckPlayerProximity();
            
            await SpawnEnemy();
        }
    }

    async Task CheckPlayerProximity()
    {
        while (!playerInSpawnRange)
        {
            await Task.Yield();
        }
    }
    async Task SpawnEnemy()
    {
        int enemySelector = r.Next(1, 6);

        if (enemySelector > 3)
        {
            enemy = Instantiate(unicyclist, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        }
        else
        {
            enemy = Instantiate(slapper, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        }

        float nextEnemySpawnTime = Time.time + spawnDelay;
        while (Time.time < nextEnemySpawnTime)
        {
            await Task.Yield();
        }
    }
}
