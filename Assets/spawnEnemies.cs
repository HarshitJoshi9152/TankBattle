using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;
    public int SpawnLimit = 10;

    // State
    float timePassed;
    List<GameObject> EnemiesSpawned = new List<GameObject>();
    float SpawnCount = 0;
    void Start()
    {
        if (EnemyPrefab == null)
        {
            Debug.LogError("NO ENEMY PREFAB SET !");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Dont Spawn More if SpawnLimit Has been reached
        if (SpawnCount > SpawnLimit) return;

        // TODO: listen for destory event on enemies and remove them from the SpawnedEnemies array
        // TODO: when they are destroyed.

        timePassed += Time.deltaTime;

        // spawn Every 5 Seconds
        if (timePassed > 5)
        {
            // select a Random Point to Spawn from list of spawn Points.
            Transform spawnPoint = getRandomSpawnPoint();
            bool spawned = spawnEnemy(spawnPoint);

            // // try the no of SpawnPoints Available.
            // // TODO: maybe even this will not cycle through all lol coz its random
            // int tryCount = 0;
            // while (spawned == false && tryCount <= SpawnPoints.Length - 1)
            // {
            //     tryCount++;
            //     // retry spawning !
            //     spawnPoint = getRandomSpawnPoint();
            //     spawned = spawnEnemy(spawnPoint);
            // }

            // reset timer to spawn
            timePassed = 0;
        }
    }

    Transform getRandomSpawnPoint()
    {
        int randomInt = Random.Range(0, SpawnPoints.Length);
        Transform spawnPoint = SpawnPoints[randomInt];
        return spawnPoint;
    }

    bool spawnEnemy(Transform spawnPoint)
    {
        // check if spawnPoint is free
        // todo: add Trigger based check
        // if (spawnIsFree(spawnPoint) == false) return false;

        // Spawn at the given Location !

        EnemiesSpawned.Add(
            Instantiate(EnemyPrefab, spawnPoint)
        );

        SpawnCount += 1;
        return true;
    }

    // todo: make the spawn have BoxCollider triggers !
    bool spawnIsFree(Transform spawnPoint)
    {
        //  Loop over the Tanks Spawned and check if they collide with the given location
        foreach (var enemy in EnemiesSpawned)
        {
            if (enemy.transform.position == spawnPoint.position)
            {
                return false;
            }
        }
        return true;
    }
}
