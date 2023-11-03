using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private Vector3[] patrol;
    private GameObject player;
    public Transform firepoint;
    public Transform offset;
    [SerializeField] private characters Character;
    public enum weapontype { range, combo, melee, boss }
    public weapontype weapon;
    private GameObject Bullet;
    private int index = 0;
    private bool attack;
    private bool chase;
    private float attackspeed=0;
    private int health;
    private bool facingRight = true;
    private bool facingForward = true;
    private Sprite[] sprite= new Sprite[2];
    [SerializeField] private GameObject attackpoint;
    [SerializeField] private GameObject chasepoint;
    [SerializeField] private GameObject inverseChasePoint;
    private float speed;
    private int damage;
    private int point;









    private void Awake()
    {
        patrol = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            patrol[i] = points[i].position;
        }


        chase = false;
        
        player = GameObject.Find("Player");

        setWeapon();

    }


    private void Update()
    {
       


        if (chase == false)
        {
            if (transform.position != patrol[index])
            {
                transform.position = Vector3.MoveTowards(transform.position, patrol[index], speed);
                if (attack == false)
                {
                    if (transform.position.x < patrol[index].x && !facingRight )
                    {
                        GameManager.current.Flip(gameObject);
                        GameManager.current.Flip(offset.gameObject);
                        facingRight = !facingRight;
                    }
                    if (transform.position.x > patrol[index].x && facingRight )
                    {
                        GameManager.current.Flip(gameObject);
                        GameManager.current.Flip(offset.gameObject);
                        facingRight = !facingRight;
                    }
                    if (transform.position.y < patrol[index].y && !facingForward )
                    {
                        
                        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
                        facingForward = !facingForward;
                    }
                    if (transform.position.y > patrol[index].y && facingForward )
                    {
                       
                        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];
                        facingForward = !facingForward;
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

        if (chase == true)
        {
            if (weapon == weapontype.range)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
               
            }
            else
            {
                Vector3 playerleft = new Vector3(player.transform.position.x - 1.8f, player.transform.position.y, player.transform.position.z);
                Vector3 playerright = new Vector3(player.transform.position.x + 1.8f, player.transform.position.y, player.transform.position.z);

                if (transform.position.x > player.transform.position.x)  transform.position = Vector3.MoveTowards(transform.position, playerright, speed);
                if (transform.position.x < player.transform.position.x) transform.position = Vector3.MoveTowards(transform.position, playerleft, speed);

                
            }


            //sprite direction
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
            if (transform.position.y < player.transform.position.y && !facingForward)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
                facingForward = !facingForward;
            }
            if (transform.position.y > player.transform.position.y && facingForward)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];
                facingForward = !facingForward;
            }

        }

        if (attack == true)
        {

            //attack
            if (attackspeed <= 0)
            {
                switch (weapon)
                {
                    case weapontype.range:
                        GameManager.current.Fire(firepoint, Bullet, damage);
                        attackspeed = 40;
                        break;

                    case weapontype.melee:
                        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0), ForceMode2D.Impulse);



                        if (transform.position.y - 1 < player.transform.position.y && player.transform.position.y < transform.position.y + 1 && player.transform.position.x > transform.position.x - 2 && player.transform.position.x < transform.position.x + 2)
                        {
                            GameManager.current.melee(firepoint, Bullet, damage);
                            attackspeed = 100;
                        }
                        

                        break;
                    case weapontype.combo:
                        if (chase == true)
                        {
                            if (transform.position.y - 1 < player.transform.position.y && player.transform.position.y < transform.position.y + 1 && player.transform.position.x > transform.position.x - 2 && player.transform.position.x < transform.position.x + 2)
                            {
                                GameManager.current.melee(firepoint, Bullet,2);
                                attackspeed = 100;
                            }
                        }
                        else
                        {
                            GameManager.current.Fire(firepoint, Bullet, damage);
                            attackspeed = 40;
                        }
                        break;
                    case weapontype.boss:
                        switch (Character.boss)
                        {
                            case "classic":
                                GameManager.current.Fire(firepoint, Bullet, damage);
                                if (attackspeed == 5)
                                { attackspeed = 40; }
                                else { attackspeed = 5; }
                                

                                break;
                            case "rock":

                                break;
                            case "pop":
                                break;
                        }
                        break;
                }
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
        if (collision.gameObject.tag == "damage")
        {
            health -= collision.gameObject.GetComponent<bullet>().damage;
            if (health <= 0)
            {
                GameManager.current.decreaseEnemy(point);
                Destroy(gameObject);
                if (weapon==weapontype.boss)
                {
                    GameManager.current.BossKill();
                }
            }
        }
    }

    public void changeState(string state, bool statechange)
    {
        if (state == "attack") attack = statechange;
        if (state == "chase") chase = statechange;
    }


    private void setWeapon()
    {
        switch (weapon)
        {
            case weapontype.range:
                sprite[0] = Character.sprites[0];
                sprite[1] = Character.sprites[1];
                Bullet = Character.Bullets[0];
                health = 2;
                attackpoint.GetComponent<CircleCollider2D>().radius = 5;
                chasepoint.GetComponent<CircleCollider2D>().radius = 3;
                inverseChasePoint.GetComponent<CircleCollider2D>().radius = 2;
                speed = .005f;
                damage = 1;
                point = 1;
                break;
             
            case weapontype.melee:
                sprite[0] = Character.sprites[2];
                sprite[1] = Character.sprites[3];
                Bullet = Character.Bullets[2];
                health = 6;
                attackpoint.GetComponent<CircleCollider2D>().radius = 1.3f;
                chasepoint.GetComponent<CircleCollider2D>().radius = 5;
                inverseChasePoint.GetComponent<CircleCollider2D>().radius = 1;
                speed = .01f;
                damage = 2;
                point = 1;
                break;
            case weapontype.combo:
                sprite[0] = Character.sprites[4];
                sprite[1] = Character.sprites[5];
                Bullet = Character.Bullets[1];
                health = 4;
                attackpoint.GetComponent<CircleCollider2D>().radius = 5;
                chasepoint.GetComponent<CircleCollider2D>().radius = 3;
                inverseChasePoint.GetComponent<CircleCollider2D>().radius = 1;
                speed = .008f;
                damage = 1;
                point = 1;
                break;
            case weapontype.boss:
                sprite[0] = Character.sprites[6];
                sprite[1] = Character.sprites[7];
                Bullet = Character.Bullets[4];
                health = 10;
                attackpoint.GetComponent<CircleCollider2D>().radius = 5;
                chasepoint.GetComponent<CircleCollider2D>().radius = 3;
                inverseChasePoint.GetComponent<CircleCollider2D>().radius = 1;
                speed = .008f;
                damage = 1;
                point = 5;
                break;


        }
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];
    }


}
