using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptableobjects/Characters")]
public class characters : ScriptableObject
{
    
    //lists corrospond to enemy  mellee classical front, back, and pop then rock 
    public List<Sprite> sprites;
    public List<GameObject> Bullets;
    
    
    
}
