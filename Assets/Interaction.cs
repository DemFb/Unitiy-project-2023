using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InteractableType { Enemy, Player, HealOrb, ManaOrb }

public class Interaction : MonoBehaviour
{

    public EnemyHealth mobsHealth;

    public PlayerHealth playerHealth;

    public InteractableType interactionType;


    void Awake()
    {
     if(interactionType == InteractableType.Enemy)
        {
            mobsHealth = GetComponent<EnemyHealth>();
        }
        if(interactionType == InteractableType.Player)
        {
            playerHealth = GetComponent<PlayerHealth>();
        }
    }
}
