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
    

    public MobsHealth mobsHealth;
    public BossHealth bossHealth;
    public PlayerController playerController;

    private bool boss;
    private bool mobs;

    private void OnTriggerEnter(Collider collider)
    {
        boss = collider.CompareTag("Boss");
        mobs = collider.CompareTag("Mobs");

        print("BEFORE: " + playerController.animator.GetBool("Attack"));

        if (playerController.animator.GetBool("Attack") == true)
            print("AFTER: " + playerController.animator.GetBool("Attack"));
        {
            if(boss)
            {
               // collider.GetComponent<Stats>().TakeDamage(targetEnemy, SwordDamage);
                collider.GetComponent<BossHealth>().TakeDamage(SwordDamage);

            }
            if (mobs)
            {
             //   collider.GetComponent<Stats>().TakeDamage(targetEnemy, SwordDamage);
                collider.GetComponent<MobsHealth>().TakeDamage(SwordDamage);

            }
        }


    }

}
