using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    

    int enemyCount=0;
    int level;
    public event Action ondeath;
    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        level = 1;
    }


    
    public void endGame()
    {
    }

    public void decreaseEnemy()
    {
        enemyCount -= 1;
        if (enemyCount == 0)
        {
            
            level += 1;
            if(ondeath != null)
            {
                ondeath();
            }
            

        }

    }

    public void setEnemy(int num)
    {
        enemyCount = num;
    }
}
