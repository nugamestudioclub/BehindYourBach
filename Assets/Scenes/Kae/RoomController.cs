using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject entryDoor;
    [SerializeField] private GameObject exitDoor;
    public EnemyList enemylist;

    private void Start()
    {
        entryDoor.gameObject.SetActive(false);
        
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        FindObjectOfType<GameManager>().SpawnEnemy(enemylist, this.transform);
        entryDoor.gameObject.SetActive(true);
        FindObjectOfType<GameManager>().setEnemy(enemylist.enemies.Length);
        this.GetComponent<BoxCollider2D>().enabled = false;
        GameManager.current.ondeath += ExitRoom;
    }

    private void ExitRoom()
    {
        exitDoor.gameObject.SetActive(false);
        GameManager.current.ondeath -= ExitRoom;


    }
}
