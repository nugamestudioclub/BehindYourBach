using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private Vector3[] patrol;
    private GameObject player;
    public GameObject attackpoint;
    public Transform firepoint;
    public Transform offset;
    public GameObject chasepoint;
    [SerializeField]private characters Character;
    public enum weapontype { sing, violin, electricGutar, mic }
     public weapontype weapon;
     [SerializeField]
    private GameObject Bullet;
    private int index = 0;
    private bool attack;
    private bool chase;
    private float attackspeed;
    [SerializeField]public int health;
    private bool facingRight=true;





    private void Awake()
    {
        patrol = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++){
            patrol[i] = points[i].position; }
        health = Character.maxHealth;
        
        chase = false;
        chasepoint.GetComponent<CircleCollider2D>().radius = Character.attackradius/2;
        attackpoint.GetComponent<CircleCollider2D>().radius = Character.attackradius;
        attackspeed = Character.shootdelay;
        player = GameObject.Find("Player");

        
        //switch for set bullet and sprite

    }


    private void Update()
    {
        


        if (chase == false) {
            if (transform.position != patrol[index])
            { 
                transform.position = Vector3.MoveTowards(transform.position, patrol[index], Character.speed);
                if (attack == false)
                {
                    if (transform.position.x < patrol[index].x && !facingRight)
                    {
                        GameManager.current.Flip(gameObject);
                        GameManager.current.Flip(offset.gameObject);
                        facingRight = !facingRight;
                    }
                    if (transform.position.x > patrol[index].x && facingRight)
                    {
                        GameManager.current.Flip(gameObject);
                        GameManager.current.Flip(offset.gameObject);
                        facingRight = !facingRight;
                    }
                }


            }
            if (transform.position == patrol[index])
            {
                if (index == patrol.Length - 1)
                {
                    index = 0;
                }
                else { index += 1; }
            }
        }

        if (chase==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Character.speed);
            
        }

        if (attack == true)
        {
            
            if (attackspeed <= 0)
            {
                GameManager.current.Fire(firepoint, Bullet);
                attackspeed = Character.shootdelay;
                
            }
            if (transform.position.x < player.transform.position.x && !facingRight)
            {
                GameManager.current.Flip(gameObject);
                GameManager.current.Flip(offset.gameObject);
                facingRight = !facingRight;
            }
            if (transform.position.x > player.transform.position.x && facingRight)
            {
                GameManager.current.Flip(gameObject);
                GameManager.current.Flip(offset.gameObject);
                facingRight = !facingRight;
            }
        }




        Vector3 aimDirection = player.transform.position - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        offset.eulerAngles = new Vector3(0, 0, angle);

        

    }
    private void FixedUpdate()
    {
        attackspeed -= 1;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "damage") {
            health -= 1;
            if (health <= 0)
            {

                GameManager.current.decreaseEnemy();
                Destroy(gameObject);
            }
        }
    }

    public void changeState(string state, bool statechange)
    {
        if(state=="attack") attack = statechange;
        if(state=="chase")chase = statechange;
    }



}
