//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(Stats))]
//public class MeleeCombat : MonoBehaviour
//{

//    private Stats stats;
//    private Animator animator;

//    [Header("Target")]
//    public GameObject targetEnemy;

//    [Header("Melee Attack Variables")]
//    public bool performMeleeAttack = true;
//    private float attackInterval;
//    private float nextAttackTime = 0;


//    // Start is called before the first frame update
//    void Start()
//    {
//        stats = GetComponent<Stats>();
//        animator = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        attackInterval = stats.attackSpeed / ((500 + stats.attackSpeed) * 0.01f);
//        StartCoroutine(MeleeAttackInterval());
//    }

//    private IEnumerator MeleeAttackInterval()
//    {
//        performMeleeAttack = false;
//        animator.SetBool("isAttacking", true);

//        yield return new WaitForSeconds(attackInterval);

//    }
//}
