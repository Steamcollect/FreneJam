using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnStats[] enemySpawnStats;

    public Transform enemysContent;

    Transform player;
    CouldownManager couldownManager;
    EnemyManager enemyManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        couldownManager = FindFirstObjectByType<CouldownManager>();
        enemyManager = FindFirstObjectByType<EnemyManager>();
    }

    private void Update()
    {
        if (player == null) return;

        for (int i = 0; i < enemySpawnStats.Length; i++)
        {
            if (enemySpawnStats[i].haveTheLevelToSpawn && enemySpawnStats[i].timer >= enemySpawnStats[i].spawningDelay)
            {
                enemySpawnStats[i].timer = 0;

                Vector2 randomPointAroundPlayer = (Vector2)player.position + (Random.insideUnitCircle.normalized * 20);
                GameObject current = Instantiate(enemySpawnStats[i].enemyPrefabs, enemysContent);
                current.transform.position = randomPointAroundPlayer;
                enemyManager.enemys.Add(current.GetComponent<EnemyController>());
            }

            enemySpawnStats[i].timer += Time.deltaTime;
        }
    }
}

[System.Serializable]
public class EnemySpawnStats
{
    public GameObject enemyPrefabs;

    public float spawningDelay;
    public float timer;

    public bool haveTheLevelToSpawn = false;
}