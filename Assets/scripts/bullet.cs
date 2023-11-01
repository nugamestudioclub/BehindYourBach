using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    private int bounce = 2;
    private float lifespan = 100;
    private Rigidbody2D rb;
    private Vector3 lastVelocity;
    public bool ismelee=false;
    public int damage;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (ismelee==true) { lifespan = 20; }
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
       
        
    }
    private void FixedUpdate()
    {
        lifespan -= 1;
        if (lifespan == 0) Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ismelee == false)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            if (bounce > 0)
            {


                rb.velocity = direction * Mathf.Max(speed, 0f);
                bounce -= 1;


            }

            else { Destroy(gameObject); }
        }
        else {
            Destroy(gameObject,.01f);

        }


    }

}
