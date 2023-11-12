using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxhealth;
    public int currentHealth;

    void Awake()
    {
        currentHealth = maxhealth;
        print("Current health: " + currentHealth);

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        print("health left: " + currentHealth);
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}

