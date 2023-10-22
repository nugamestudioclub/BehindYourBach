using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Transform[] patrol;
    private Rigidbody2D ridge2D;

    private int health=2;
    private int speed = 2;

    private void Awake()
    {
        ridge2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        for(int i = 0; i < patrol.Length; i++)
        {
            while (transform.position != patrol[i].position) 
            { transform.position = Vector3.MoveTowards(transform.position, patrol[i].position, speed); }

        }
    }


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
