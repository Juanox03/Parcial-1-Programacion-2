using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float life;

    public abstract void Damage();

    public virtual void TakeDamage(float dmg)
    {
        

        if (life <= 0)
            Debug.Log("GAME OVER");
    }
}