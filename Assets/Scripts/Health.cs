using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float meleeDamage = 0f;
    protected float health = 100;
    protected float pointReward = 0;

    public abstract void Die();

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0) Die();
    }
}
