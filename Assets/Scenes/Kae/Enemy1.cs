using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private Vector3[] patrol;
    


    private int health=2;
    private float speed = .006f;
    private int index = 0;

    
    private void Start()
    {
        patrol = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++){
            patrol[i] = points[i].position; }
    }


    private void Update()
    {
        
       
        
        if (transform.position != patrol[index]) 
            { transform.position = Vector3.MoveTowards(transform.position, patrol[index], speed); }
        if(transform.position == patrol[index])
        {
            if (index == patrol.Length-1)
            {
                index = 0;
            }
            else { index += 1; }
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
