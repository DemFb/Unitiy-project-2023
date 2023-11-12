using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InteractableType { Mobs, Player, Boss, HealOrb, ManaOrb }

public class Interaction : MonoBehaviour
{

    public MobsHealth mobsHealth;

    public PlayerHealth playerHealth;

    public InteractableType interactionType;


    void Awake()
    {
     if(interactionType == InteractableType.Mobs)
        {
            mobsHealth = GetComponent<MobsHealth>();
        }
        if (interactionType == InteractableType.Boss)
        {
            mobsHealth = GetComponent<MobsHealth>();
        }
        if(interactionType == InteractableType.Player)
        {
            playerHealth = GetComponent<PlayerHealth>();
        }

        //switch (interactionType)
        //{
        //    case InteractableType.Mobs:
        //        mobsHealth = GetComponent<MobsHealth>();
        //        break;
        //    case InteractableType.Boss:
        //        mobsHealth = GetComponent<MobsHealth>();
        //        print("attack to boss");
        //        break;
        //    case InteractableType.Player:
        //        // code block
        //        break;
        //    case InteractableType.ManaOrb:
        //        // code block
        //        break;
        //    case InteractableType.HealOrb:
        //        // code block
        //        break;
        //    default:
        //        yield return null;
        //        break;
        //}
    }

    //public void OrbInteraction(int amount)
    //{
    //    if(interactionType == InteractableType.HealOrb)
    //    {
    //        Destroy(gameObject);
    //    }
    //    if (interactionType == InteractableType.ManaOrb)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
