using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhit : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "damage")
        {
            GetComponentInParent<playercontroller2>().lives -= 1;
            
        }
    }
}
