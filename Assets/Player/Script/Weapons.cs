using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int SwordDamage = 3;
    public Animator animator;


    public List<GameObject> targetEnemies;

    public PlayerController playerController;


    private void OnTriggerEnter(Collider collider)
    {

        print("BEFORE: " + playerController.animator.GetBool("Attack"));

        if (playerController.animator.GetBool("Attack") == true && collider.CompareTag("Enemy"))
            print("AFTER: " + playerController.animator.GetBool("Attack"));
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(SwordDamage);
        }

    }

}
