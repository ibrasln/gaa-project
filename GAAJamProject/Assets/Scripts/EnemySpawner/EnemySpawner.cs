using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> enemySpawnPositions = new();
    [SerializeField] private Transform academy;
    [SerializeField] private List<GameObject> enemies = new();

    [SerializeField] private float enemySpawnCooldown;
    private float enemySpawnTimer;

    private void Start()
    {
        enemySpawnTimer = enemySpawnCooldown;

        for (int i = 0; i < academy.childCount;  i++)
        {
            enemySpawnPositions.Add(academy.GetChild(i));
        }
    }

    private void Update()
    {
        if (enemySpawnTimer < 0)
        {
            SpawnEnemy();
            enemySpawnTimer = enemySpawnCooldown;
        }
        else
        {
            enemySpawnTimer -= Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        int randIndex = Random.Range(0, enemySpawnPositions.Count);

        if (enemySpawnPositions[randIndex].GetComponent<EnemySpawnPosition>().CanSpawnEnemy) 
        {
            int randEnemyIndex = Random.Range(0, enemies.Count);
            GameObject enemy = Instantiate(enemies[randEnemyIndex], enemySpawnPositions[randIndex].position, Quaternion.identity);
            if (academy.position.x > enemy.transform.position.x)
            {
                enemy.transform.localScale = Vector3.one;
            }
            else
            {
                enemy.transform.localScale = new(-1, 1, 1);
            }
        }
    }
}
