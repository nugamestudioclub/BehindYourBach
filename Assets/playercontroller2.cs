using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller2 : MonoBehaviour
{//transfer to player controller
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float fireforce = 20f;
    public int firespeed = 20;


    Vector2 moveDirection;
    Vector2 mousePosition;

    


    
    private void Update()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(movex,movey).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && firespeed < 0)
        {
            Fire();
            firespeed = 20;
        }
    }

    private void FixedUpdate()
    {
        firespeed -= 1;
        Vector2 aimDirection = mousePosition - firepoint.GetComponent<Rigidbody2D>().position;
        float aimangle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90;
        firepoint.GetComponent<Rigidbody2D>().rotation = aimangle;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }

    public void Fire()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireforce, ForceMode2D.Impulse);
    }

}
