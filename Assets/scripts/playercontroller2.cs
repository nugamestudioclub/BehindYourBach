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
    public bool hasmic = false;
    public bool hasviolin = false;
    public bool hasgutar = false;
    private float holdcount;
    string[] words = new string[1];





    private void Start()
    {
        lives = 5;
        rb = GetComponent<Rigidbody2D>();
        weapon = weapontype.violin;
        hasviolin = GameManager.current.violin;
        hasmic= GameManager.current.mic;
        hasgutar = GameManager.current.gutar;
       
        
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

        
        if (Input.GetKeyDown("1")) { weapon = weapontype.sing; Debug.Log(weapon); }
        if (Input.GetKeyDown("2" )&& hasmic == true) { weapon = weapontype.mic; Debug.Log(weapon); }
        if (Input.GetKeyDown("3") && hasgutar==true) { weapon = weapontype.Egutar; Debug.Log(weapon); }
        if (Input.GetKeyDown("4") && hasviolin==true) { weapon = weapontype.violin; Debug.Log(weapon); }




        if (Input.GetMouseButton(0) && firespeed < 0)
        {
           
            switch (weapon)
            {
                case (weapontype.sing):

                    GameManager.current.Fire(firepoint, bulletPrefab,1);
                    firespeed = 20;
                    break;
                case (weapontype.mic):
                    GameManager.current.micAttack(gameObject, bulletPrefab);
                    firespeed = 40;
                    break;
                case (weapontype.violin):
                   

                    holdcount += 1;
                    
                    
                    
                    
                    break;
                case (weapontype.Egutar):
                    GameManager.current.gutarAttack(firepoint, bulletPrefab);
                    firespeed = 40;
                    break;
            }
        }
       
         if (Input.GetMouseButtonUp(0) && weapon == weapontype.violin)
         {
            Debug.Log(holdcount);
            GameManager.current.violinAttack(firepoint, bulletPrefab, holdcount);
            holdcount = 0;
            firespeed = 40;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "mic" && hasmic==false)
        {
            hasmic = true;
            GameManager.current.mic = true;

            
            words[0] = "you found a mic";
            Dialog dialog=new Dialog();
            dialog.sentences = words;
            GameManager.current.startDialog(dialog);

        }
        if (collision.gameObject.tag == "violin" && hasviolin==false)
        {
            hasviolin = true;
            GameManager.current.violin = true;

            words[0] = "you found a violin";
            Dialog dialog = new Dialog();
            dialog.sentences = words;
            GameManager.current.startDialog(dialog);
        }
        if (collision.gameObject.tag == "gutar" && hasgutar==false)
        {
            hasgutar = true;
            GameManager.current.gutar = true;

            words[0] = "you found a guitar";
            Dialog dialog = new Dialog();
            dialog.sentences = words;
            GameManager.current.startDialog(dialog);
        }

        if (collision.gameObject.tag == "exit")
        {
            GameManager.current.LoadScene("Level"+ GameManager.current.level);
        }

    }







}
