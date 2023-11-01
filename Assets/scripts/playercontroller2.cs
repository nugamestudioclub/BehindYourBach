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
    private enum weapontype { sing, mic, violin, Egutar }
    private weapontype weapon;
    private bool hasmic = false;
    private bool hasviolin = false;
    private bool hasgutar = false;





    private void Start()
    {
        lives = 5;
        rb = GetComponent<Rigidbody2D>();
        weapon = weapontype.Egutar;
       
        
    }


    /*
    public void gutarAttacksetup(Transform thisgame, GameObject Bullet)
    {

        //make two points that will be the firepoint for two extra bullets ,make firepoint the parent so it moves with firepoint
        GameObject emptyGO = new GameObject();
        
        Vector3[] veclist = new Vector3[3];

        veclist[1] = thisgame.transform.position;//original
        veclist[2] = new Vector3(thisgame.transform.position.x - 1f, thisgame.transform.position.y - .2f);//left
        veclist[0] = new Vector3(thisgame.transform.position.x + 1f, thisgame.transform.position.y - .2f);//right


        for (int i = 0; i < 3; i++)
        {
            if (i == 0) { emptyGO.transform.eulerAngles = new Vector3(thisgame.transform.eulerAngles.x, thisgame.transform.eulerAngles.y, thisgame.transform.eulerAngles.z + 10); }
            if (i == 2) { emptyGO.transform.eulerAngles = new Vector3(thisgame.transform.eulerAngles.x, thisgame.transform.eulerAngles.y, thisgame.transform.eulerAngles.z + 10); }
            emptyGO.transform.localPosition = veclist[i];
            GameManager.current.Fire(emptyGO.transform, Bullet);
            Destroy(emptyGO);
        }
    }

    */











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


        if (Input.GetKeyDown("1")) { Debug.Log("1"); }




        if (Input.GetMouseButtonDown(0) && firespeed < 0)
        {
            

            switch (weapon)
            {
                case (weapontype.sing):

                    GameManager.current.Fire(firepoint, bulletPrefab);
                    firespeed = 20;
                    break;
                case (weapontype.mic):
                    GameManager.current.micAttack(gameObject, bulletPrefab);
                    firespeed = 40;
                    break;
                case (weapontype.violin):
                    break;
                case (weapontype.Egutar):
                    GameManager.current.gutarAttack(firepoint, bulletPrefab);
                    break;
            }





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
          if ((collision.gameObject.transform.position.x > transform.position.x && facingRight) ) {
                if (isStunned == false)
                {
                    GameManager.current.Flip(gameObject);
                    GameManager.current.Flip(offset.gameObject);
                    facingRight = !facingRight;
                    isStunned = true;
                    stunTime = 150;
                }
           }
           if(collision.gameObject.transform.position.x < transform.position.x && !facingRight)
            {
                GameManager.current.Flip(gameObject);
                GameManager.current.Flip(offset.gameObject);
                facingRight = !facingRight;
                isStunned = true;
                stunTime = 150;
            }
        }
    }







}
