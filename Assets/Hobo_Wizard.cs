using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobo_Wizard : MonoBehaviour
{
    public float health = 100f;
    public float acidicStream = 25f;
    public float speed = 10f;

    public Hobo_Wizard() { }

    public void Move()
    {

    }
    public void AcidicStreamAttack()
    {

    }

    public void Stun()
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
        stun();
    }
    private void Die()
    {
        Destroy(gameObject);
        // drops wizards gale right after it dies
    }
}
