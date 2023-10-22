using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject entryDoor;
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private GameObject enemies;
    [SerializeField] private int enemyCount;
    

    private void Start()
    {
        entryDoor.gameObject.SetActive(false);
        enemies.gameObject.SetActive(false);


    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        entryDoor.gameObject.SetActive(true);
        GameManager.current.setEnemy(enemyCount);
        enemies.gameObject.SetActive(true);
        this.GetComponent<BoxCollider2D>().enabled = false;
        GameManager.current.ondeath += ExitRoom;

    }

    private void ExitRoom()
    {
        exitDoor.gameObject.SetActive(false);
        GameManager.current.ondeath -= ExitRoom;


    }
}
