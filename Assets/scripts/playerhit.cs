using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhit : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "damage")
        {


            if (collision.gameObject.GetComponent<bullet>().damage > 3) 
            {
                GetComponentInParent<playercontroller2>().lives -= 2;
                GameManager.current.decreaseHealth(2);
            }
            else
            {
                GetComponentInParent<playercontroller2>().lives -= collision.gameObject.GetComponent<bullet>().damage;
                GameManager.current.decreaseHealth(collision.gameObject.GetComponent<bullet>().damage);
            }
                
            
            

        }
        

    }


}
