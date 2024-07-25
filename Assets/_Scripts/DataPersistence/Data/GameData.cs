using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class GameData 
{    
    public int maxHealth=100;
    public int health=100;
    public float walkSpeed = 5;
    public float runSpeed=8;
    public float airSpeed = 5;
    public float jumpImpulse = 10;
    public int attackDamage = 15;
    public Vector2 meleeKnockback = new Vector2(2,0); 
}
