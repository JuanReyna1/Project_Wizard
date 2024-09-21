using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float attackOne = 5f;
    public float attackTwo = 5f;
    public float speed = 10f;

    public Player() { }

    public void Move()
    {

    }
    public void AttackOne()
    {

    }
    
    public void AttackTwo()
    {

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

        Destroy(gameObject, 3f);
    }
}
