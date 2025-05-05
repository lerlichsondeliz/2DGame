using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int initialEnemies = 5;
    public float spawnRadius = 5f;
    public float spawnDelay = 2f;

    private int currentWave = 1;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private bool isSpawning = false;

    void Start()
    {
        SpawnEnemies(initialEnemies);
    }

    void Update()
    {
        // Remove dead (destroyed) enemies
        activeEnemies.RemoveAll(e => e == null);

        // Trigger next wave when all enemies are gone
        if (activeEnemies.Count == 0 && !isSpawning)
        {
            StartCoroutine(SpawnNextWave());
        }
    }

    IEnumerator SpawnNextWave()
    {
        isSpawning = true;

        yield return new WaitForSeconds(spawnDelay);

        currentWave++;
        int enemiesToSpawn = initialEnemies + (currentWave - 1) * 5;

        SpawnEnemies(enemiesToSpawn);
        isSpawning = false;
    }

    void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            activeEnemies.Add(newEnemy);
        }

        Debug.Log($"Wave {currentWave}: Spawned {count} enemies.");
    }
}
