using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void startbutton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void main()
    {
        SceneManager.LoadScene("main menu");
    }
}
