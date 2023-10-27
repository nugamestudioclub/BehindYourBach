using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptableobjects/Characters")]
public class characters : ScriptableObject
{
    
    public float shootdelay;
    //lists corrospond to weapon  sing Ghost front, back, and bullet then mic then gutar then violin
    public List<Sprite> sprites;
    public List<GameObject> Bullets;
    public int maxHealth;
    public float speed;
    public int attackradius;
    
}
