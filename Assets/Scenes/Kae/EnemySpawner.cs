using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Object> enemies;

    private void Start()
    {
        enemies = new List<Object>();
    }

    public void SpawnEnemy(EnemyList enemylist)
    {
        Debug.Log("spawning"+ enemylist.enemies[1]);

    }
}
