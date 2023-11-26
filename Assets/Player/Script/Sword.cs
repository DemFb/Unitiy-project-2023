using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Sword : MonoBehaviour
{
    public int SwordDamage = 3;
    public Animator animator;


    private Stats stats;
    public GameObject targetEnemy;
    

    //public MobsHealth mobsHealth;
    //public BossHealth bossHealth;
    public PlayerController playerController;


    private void OnTriggerEnter(Collider collider)
    {

        print("BEFORE: " + playerController.animator.GetBool("Attack"));

        if (playerController.animator.GetBool("Attack") == true)
            print("AFTER: " + playerController.animator.GetBool("Attack"));
        {
            if(collider.CompareTag("Boss"))
            {
              //  collider.GetComponent<BossHealth>().TakeDamage(SwordDamage);
                collider.GetComponent<Stats>().TakeDamage(targetEnemy, SwordDamage);
            }
            if(collider.CompareTag("Mobs"))
            {
                collider.GetComponent<MobsHealth>().TakeDamage(SwordDamage);
            }
        }


    }

}
