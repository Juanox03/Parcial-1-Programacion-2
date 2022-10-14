using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public override void Damage()
    {
        Debug.Log("ATTACK ENEMY");
        
    }
    public override void TakeDamage(float dmg)
    {
        life -= dmg;

        if (life <= 0)
            Destroy(gameObject);
    }
}