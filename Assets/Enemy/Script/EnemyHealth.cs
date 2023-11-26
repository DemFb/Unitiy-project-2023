//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyHealth : MonoBehaviour
//{
//    public int maxhealth;
//    public int currentHealth;

//    void Awake()
//    {
//        currentHealth = maxhealth;
//    }

//    public void TakeDamage(int amount)
//    {
//        currentHealth -= amount;
//        Debug.Log("CURRENT HEALTH: " + currentHealth);
//        if(currentHealth <= 0)
//        {
//            Death();
//        }
//    }

//    void Death()
//    {
//        Destroy(gameObject);
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public delegate void DeathAction(int remainingEnemies);
    public event DeathAction OnDeath;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("CURRENT HEALTH: " + currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);

        if (OnDeath != null)
        {
            OnDeath.Invoke(GetRemainingEnemies());
        }
    }

    int GetRemainingEnemies()
    {
        // Vous pouvez ajuster cette logique pour compter les ennemis restants dans votre liste ou votre gestionnaire
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
