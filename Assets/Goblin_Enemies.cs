using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;
    public float clawAttack = 25f;
    public float speed = 10f;

    public Goblin_Enemies() { }

    public void Move()
    {

    }
    public void ClawAtack(Player player)
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

        Destroy(gameObject);
        // drops fireball right after they die
    }


}
