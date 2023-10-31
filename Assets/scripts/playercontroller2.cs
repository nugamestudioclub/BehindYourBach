using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform offset;
    public Transform firepoint;
    public float fireforce = 20f;
    public int firespeed = 2;
    Vector2 moveDirection;
    public int lives;
    bool facingRight=true;
    bool isStunned = false;
    public float stunTime=10;




    private void Start()
    {
        lives = 5;
        rb = GetComponent<Rigidbody2D>();
       
        
    }
    private void Update()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(movex,movey).normalized;



         Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
       

        Vector3 aimDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg ;
        offset.eulerAngles = new Vector3(0, 0, angle);
        

        if (Input.GetMouseButtonDown(0) && firespeed < 0)
        {
            GameManager.current.Fire(firepoint,bulletPrefab);
            firespeed = 20;
        }

        if (movex >0 && !facingRight && isStunned==false)
        {
            GameManager.current.Flip(gameObject);
            GameManager.current.Flip(offset.gameObject);
            facingRight = !facingRight;
        }
        if (movex < 0 && facingRight && isStunned == false)
        {
            GameManager.current.Flip(gameObject);
            GameManager.current.Flip(offset.gameObject);
            facingRight = !facingRight;
        }
        if (lives <=0) { GameManager.current.resetScene(); ; }
    }
    

    private void FixedUpdate()
    {
        if (stunTime > -160)
        {
            stunTime -= 1;
            if (stunTime==0)
            {
                isStunned = false;
            }
        }

        firespeed -= 1;

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "meelee" || stunTime < -150)
        {
            Debug.Log("coll");
          // if ((collision.gameObject.transform.position.x > transform.position.x && !facingRight) || (collision.gameObject.transform.position.x < transform.position.x && facingRight)) {
                if (isStunned == false)
                {
                    Debug.Log("flip");
                    GameManager.current.Flip(gameObject);
                    GameManager.current.Flip(offset.gameObject);
                    facingRight = !facingRight;
                    isStunned = true;
                    stunTime = 150;
                }
           //}
        }
    }







}
