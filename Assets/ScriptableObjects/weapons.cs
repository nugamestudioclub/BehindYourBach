using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptableobjects/weapons")]
public class weapons : ScriptableObject
{
    
  



    /*
    public void micAttack(GameObject thisgame, GameObject Bullets) 
    {
        GameObject emptyGO = new GameObject();
        Vector3[] veclist = new Vector3[6];
        
        
        veclist[0] = new Vector3 (thisgame.transform.position.x, thisgame.transform.position.y+1);//top
        veclist[1] = new Vector3(thisgame.transform.position.x +.7f, thisgame.transform.position.y + .4f);//topright
        veclist[2] = new Vector3(thisgame.transform.position.x -.7f, thisgame.transform.position.y + .4f);//topleft

        veclist[3] = new Vector3(thisgame.transform.position.x, thisgame.transform.position.y - 1);//bottom
        veclist[4] = new Vector3(thisgame.transform.position.x - .7f, thisgame.transform.position.y - .4f);//botomleft
        veclist[5] = new Vector3(thisgame.transform.position.x +.7f, thisgame.transform.position.y - .4f);//bottomright


        for(int i=0; i<6; i++)
        {
            emptyGO.transform.eulerAngles = new Vector3(0, 0, i*60);
            emptyGO.transform.position = veclist[i];
            GameManager.current.Fire(emptyGO.transform,Bullets);
        }



    }
    */



}
