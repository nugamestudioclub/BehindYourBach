using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {//test enemy
       
        FindObjectOfType<GameManager>().decreaseEnemy();
        //destroy object
    }
}
