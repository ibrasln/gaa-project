using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPosition : MonoBehaviour
{
    public bool CanSpawnEnemy = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CanSpawnEnemy = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CanSpawnEnemy = true;
        }
    }
}
