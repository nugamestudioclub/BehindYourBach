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
    public void Fire(Transform firepoint, GameObject Bullet)
    {
        GameObject bullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * 20, ForceMode2D.Impulse);
        
    }
    public void melee(Transform firepoint, GameObject Bullet)
    {
        GameObject bullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * 20, ForceMode2D.Impulse);
        bullet.GetComponent<bullet>().ismelee = true;
    }

    public void Flip(GameObject objects)
    {
        Vector3 currentscale = objects.transform.localScale;
        currentscale.x *= -1;
        objects.transform.localScale = currentscale;
        
    }


    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





}
