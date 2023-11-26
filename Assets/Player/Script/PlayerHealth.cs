using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public Animator animator;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        currentHealth = maxHealth;
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        print("MAX VALUE: " + healthBar.maxValue);
        print("CURRENT VALUE: " + healthBar.value);

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
            print(currentHealth + "CURRENT HEALTH PLAYER");
        }
       
    }
    public void SetHealthUI(int hp)
    {
        healthBar.value = hp;
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        print("TAKE DAMAGE: " + damage);

        if(currentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
        }
    }

    void Heal(int amount)
    {
        currentHealth += amount;

        print("TAKE DAMAGE: " + amount);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
