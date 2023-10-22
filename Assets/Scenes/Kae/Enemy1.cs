using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int health=2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
        if (health <= 0)
        {
            GameManager.current.decreaseEnemy();
            Destroy(this.gameObject);
            
        }
    }

    


}
