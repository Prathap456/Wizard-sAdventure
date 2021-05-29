using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float maxHealth;
    public float minHealth;
    public float health;
    public float damage;

    private void Start()
    {
        health = maxHealth;
    }

    public void takeDamage()
    {
        
        health -= damage;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            takeDamage();
        }
        if (health <= minHealth)
        {
            Destroy(gameObject);
        }
    }
}
