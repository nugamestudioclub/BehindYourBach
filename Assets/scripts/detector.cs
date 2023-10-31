using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    private GameObject player;
    public enum state { attack, chase }
    public state State;

    public bool inverse=false;


    public void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            this.GetComponentInParent<Enemymovement>().changeState(State.ToString(), !inverse);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {

            this.GetComponentInParent<Enemymovement>().changeState(State.ToString(), inverse);

        }
    }
}
