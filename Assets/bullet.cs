using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public string Type;//type should refernec scriptable object
    private int bounce = 3;

    //type includes damage, sprite, player sprite set sprite set is front back code should flip
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        //if wall bounce if still have bounces
        //if hit weakpoint do deamage of its type
        //
    }

}
