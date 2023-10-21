using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
     private const float MOVE_SPEED = 5f;
    private int lives;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        lives = 3;
    }
    private void Update()
    {
        float movex = 0f;
        float movey = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            movey = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movey = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movex = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movex = +1f;
        }

        moveDir = new Vector3(movex, movey).normalized;

    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDir* MOVE_SPEED;
    }
}
