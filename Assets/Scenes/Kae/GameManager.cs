using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    int enemyCount=0;
    int level;

    private void Start()
    {
        level = 1;
    }


    public void openDoor()
    {
        //observer
    }
    public void endGame()
    {
    }
    public void SpawnEnemy(EnemyList enemylist, Transform gameobject)
    {
        for (int i = 0; i < enemylist.enemies.Length; i++)
        {
            GameObject newEnemy = Instantiate(enemylist.enemies[i], enemylist.xy[i], Quaternion.identity, gameobject.transform);
        }
    }

    public void decreaseEnemy()
    {
        enemyCount -= 1;
        if (enemyCount == 0)
        {
            openDoor();
            level += 1;

        }

    }

    public void setEnemy(int num)
    {
        enemyCount = num;
    }
}
