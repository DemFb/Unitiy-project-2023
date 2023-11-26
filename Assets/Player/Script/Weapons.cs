using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int damage = 3;
    public Animator animator;


    public List<GameObject> targetEnemies;

    public PlayerController playerController;


    private void OnTriggerEnter(Collider collider)
    {

        print("BEFORE: " + playerController.animator.GetBool("Attack"));

        if (playerController.animator.GetBool("Attack") == true)
            print("AFTER: " + playerController.animator.GetBool("Attack"));
        {
            if(collider.CompareTag("Enemy"))
            {
                collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            if(collider.CompareTag("Boss"))
            {
                collider.GetComponent<BossHealth>().TakeDamage(damage);
            }
            
        }

    }

}
