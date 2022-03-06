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
    public float spawnDelay;

    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemiesLoop();
    }

    // Update is called once per frame
    void Update()
    {

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
            await SpawnEnemy();
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
