using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject entryDoor;
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private GameObject enemies;
    [SerializeField] private int enemyCount;
    

    private void Start()
    {
        entryDoor.gameObject.SetActive(false);
        enemies.gameObject.SetActive(false);
        GameManager.current.ondeath += ExitRoom;

        if (GameManager.current.level==1) {
            string[] words = new string[4];
            words[0] = "welcome to the musitian tomb where all the great names in music are buried. first basics press space for next dialog";
            words[1] = "nice you know the rest left mouse for shoot wasd and arrows to move numbers keys to switch weapon you'll figure it out";
            words[2] = "you say you want to become the best musician, what better way than proving your music is more powerful you only have singing for now but you'll pick up more instraments";
            words[3] = "as a musician yourself you must know you cant fight one head on instead aim for the back and may the best musician win";
            Dialog dialog = new Dialog();
            dialog.sentences = words;
            GameManager.current.startDialog(dialog);
            GameManager.current.indialog = true;
        }

        if (GameManager.current.level == 4)
        {
            string[] words = new string[4];
            words[0] = "congrats you bested the best";
            words[1] = "now the only thing left to wonder is where is bach";
            words[2] = "...";
            words[3] = "BEHIND YOU";
            Dialog dialog = new Dialog();
            dialog.sentences = words;
            GameManager.current.startDialog(dialog);
            
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            entryDoor.gameObject.SetActive(true);
            GameManager.current.setEnemy(enemyCount);
            enemies.gameObject.SetActive(true);
            this.GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }

    private void ExitRoom()
    {
        exitDoor.gameObject.SetActive(false);
        GameManager.current.ondeath -= ExitRoom;

    }
}
