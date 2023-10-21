using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;

    private void Start()
    {
        enemies = new List<GameObject>();
    }

    public void SpawnEnemy(EnemyList enemylist, Transform gameobject)
    {
       
        for (int i=0 ; i < enemylist.enemies.Length ; i++)
        {
            
            GameObject newEnemy= Instantiate(enemylist.enemies[i], enemylist.xy[i], Quaternion.identity, gameobject.transform);
            
        }

    }
}
