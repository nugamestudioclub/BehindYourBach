using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    int enemyCount;
    int level;

    private void Start()
    {
        enemyCount = 0;
        level = 1;
    }


    public void openDoor()
    {
        
    }

    public void startRoom()
    {
        //takes in level or which room we're in
        //close doors, spawn enemy, set count, despawns last room, spawns next room
    }
    public void endGame()
    {
        //
    }
}
