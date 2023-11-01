using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    

    int enemyCount=0;
    int level;
    public event Action ondeath;
   
    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        level = 1;
    }


    
    public void endGame()
    {
    }

    public void decreaseEnemy()
    {
        enemyCount -= 1;
        if (enemyCount == 0)
        {
            
            level += 1;
            if(ondeath != null)
            {
                ondeath();
            }
            

        }

    }

    public void setEnemy(int num)
    {
        enemyCount = num;
    }
    public void Fire(Transform firepoint, GameObject Bullet, int damage)
    {
        GameObject bullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * 20, ForceMode2D.Impulse);
        bullet.GetComponent<bullet>().damage = damage;

    }
    public void melee(Transform firepoint, GameObject Bullet,int damage)
    {
        GameObject bullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * 20, ForceMode2D.Impulse);
        bullet.GetComponent<bullet>().ismelee = true;
        bullet.GetComponent<bullet>().damage = damage;
    }

    public void Flip(GameObject objects)
    {
        Vector3 currentscale = objects.transform.localScale;
        currentscale.x *= -1;
        objects.transform.localScale = currentscale;
        
    }

    public void gutarAttack(Transform thisgame, GameObject Bullet)
    {
        GameObject emptyGO = new GameObject();
        emptyGO.transform.SetParent(thisgame, true);
        Vector3[] veclist = new Vector3[3];

        veclist[1] = new Vector3(0 ,0);//original
        veclist[2] = new Vector3( - 1f,  - .2f);//left
        veclist[0] = new Vector3( + 1f,  - .2f);//right


        for (int i = 0; i < 3; i++)
        {
            if (i == 0) { emptyGO.transform.eulerAngles = new Vector3(0, 0, thisgame.transform.eulerAngles.z - 30); }
            if (i == 1) { emptyGO.transform.eulerAngles = new Vector3(0, 0, thisgame.transform.eulerAngles.z); }
            if (i == 2) { emptyGO.transform.eulerAngles = new Vector3(0,0, thisgame.transform.eulerAngles.z + 30); }
            
            emptyGO.transform.localPosition = veclist[i];
            GameManager.current.Fire(emptyGO.transform, Bullet,1);
            Destroy(emptyGO);
        }
    }
    

    public void violinAttack(Transform firepoint, GameObject Bullet, float power)
    {
        int damage=0;
        switch (power)
        {
            case  < 200:
                Debug.Log("small");
                damage = 2;
                break;
            case < 400:
                Debug.Log("medium");
                damage = 4;
                break;
            case > 400:
                Debug.Log("large");
                damage = 6;
                break;
        }

        GameManager.current.Fire(firepoint, Bullet,damage);
        Debug.Log(damage);












    }
    public void micAttack(GameObject thisgame, GameObject Bullets)
    {
        GameObject emptyGO = new GameObject();
        Vector3[] veclist = new Vector3[6];


        veclist[0] = new Vector3(thisgame.transform.position.x, thisgame.transform.position.y + 1);//top
        veclist[5] = new Vector3(thisgame.transform.position.x + 1f, thisgame.transform.position.y + .4f);//topright
        veclist[1] = new Vector3(thisgame.transform.position.x - 1f, thisgame.transform.position.y + .4f);//topleft

        veclist[3] = new Vector3(thisgame.transform.position.x, thisgame.transform.position.y - 1);//bottom
        veclist[2] = new Vector3(thisgame.transform.position.x - 1f, thisgame.transform.position.y - .4f);//botomleft
        veclist[4] = new Vector3(thisgame.transform.position.x + 1f, thisgame.transform.position.y - .4f);//bottomright


        for (int i = 0; i < 6; i++)
        {
            emptyGO.transform.eulerAngles = new Vector3(0, 0, i * 60);
            emptyGO.transform.position = veclist[i];
            GameManager.current.Fire(emptyGO.transform, Bullets,1);
            Destroy(emptyGO);
        }

    }


    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





}
