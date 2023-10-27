using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    private int bounce = 2;
    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized,collision.contacts[0].normal);
        if (bounce > 0)
        {
            rb.velocity = direction * Mathf.Max(speed, 0f);
            bounce -= 1;
        }
        else { Destroy(gameObject); }

    }

}
