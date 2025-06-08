using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public Transform[] spawnerPoints;
    public float spawnInterval = 2f;
    public Transform enemyParent;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRandom();
            timer = 0f;
        }
    }

    private void SpawnRandom()
    {
        if (enemyPrefab == null || enemyParent == null)
        {
            Debug.LogWarning("EnemyPrefab 또는 EnemyParent가 설정되지 않음");
            return;
        }

        int randIndex = Random.Range(0, spawnerPoints.Length);
        Transform spawnPos = spawnerPoints[randIndex];

        GameObject enemy = Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity, enemyParent);
    }
}
