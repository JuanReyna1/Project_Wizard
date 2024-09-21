using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour
{
    public float health = 100f;
    public float zap = 25f;
    public float tailSwap = 25f;
    public float speed = 10f;

    public Cop() { }

    public void Move()
    {

    }
    public void ZapAttack()
    {

    }

    public void TailAttack()
    {
        // needs to make this object stop moving for a certain amount of time
    }

    public void TakeDamage(float damage)
    {
        if (health - damage < 1)
        {
            Die();
        }
        health -= damage;
    }
    private void Die()
    {
        Destroy(gameObject);
        // drops wizards gale right after it dies
    }
}
