using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    GameObject entryDoor;
    GameObject exitDoor;
    //enemy list

    //doors
    //Door.GetComponent<boxCollider>().enabled=false;
    //on trigger enter

    public EnemyList enemylist;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        FindObjectOfType<EnemySpawner>().SpawnEnemy(enemylist,this.transform);
        this.GetComponent<BoxCollider2D>().enabled = false;
        //close doors
    }
}
