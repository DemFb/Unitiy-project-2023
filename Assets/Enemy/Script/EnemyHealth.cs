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

    public delegate void DeathCount(int remainingEnemies);
    public event DeathCount OnDeathCount;

    public delegate void DeathType(SpawnEnemies.EnemyType enemyType);
    public event DeathType OnDeathType;

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

        if (OnDeathCount != null)
        {
            OnDeathCount.Invoke(GetRemainingEnemies());
        }

        if (OnDeathType != null)
        {
            OnDeathType.Invoke(GetEnemyType());
        }
    }

    int GetRemainingEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    SpawnEnemies.EnemyType GetEnemyType()
    {
        if (gameObject.CompareTag("Boss"))
        {
            return SpawnEnemies.EnemyType.Boss;
        }
        else
        {
            return SpawnEnemies.EnemyType.Enemy;
        }
    }
}
