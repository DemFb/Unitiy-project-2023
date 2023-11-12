using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public Text abilityText1;
    public KeyCode ability1key;
    public float ability1Cooldown = 5;

    [Header("Ability 2")]
    public Image abilityImage2;
    public Text abilityText2;
    public KeyCode ability2key;
    public float ability2Cooldown = 7;

    [Header("Ability 3")]
    public Image abilityImage3;
    public Text abilityText3;
    public KeyCode ability3key;
    public float ability3Cooldown = 10;

    [Header("Ability 4")]
    public Image abilityImage4;
    public Text abilityText4;
    public KeyCode ability4key;
    public float ability4Cooldown = 12;

    [Header("Ability 5")]
    public Image abilityImage5;
    public Text abilityText5;
    public KeyCode ability5key;
    public float ability5Cooldown = 14;

    private bool isAbility1Cooldown = false;
    private bool isAbility2Cooldown = false;
    private bool isAbility3Cooldown = false;
    private bool isAbility4Cooldown = false;
    private bool isAbility5Cooldown = false;

    private float currentAbility1Cooldown;
    private float currentAbility2Cooldown;
    private float currentAbility3Cooldown;
    private float currentAbility4Cooldown;
    private float currentAbility5Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;
        abilityImage5.fillAmount = 0;

        abilityText1.text = "";
        abilityText2.text = "";
        abilityText3.text = "";
        abilityText4.text = "";
        abilityText5.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        AbilityInput();

        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, abilityText1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage2, abilityText2);
        AbilityCooldown(ref currentAbility3Cooldown, ability3Cooldown, ref isAbility3Cooldown, abilityImage3, abilityText3);
        AbilityCooldown(ref currentAbility4Cooldown, ability4Cooldown, ref isAbility4Cooldown, abilityImage4, abilityText4);
        AbilityCooldown(ref currentAbility5Cooldown, ability5Cooldown, ref isAbility5Cooldown, abilityImage5, abilityText5);
    }

    private void AbilityInput()
    {
        if(Input.GetKeyDown(ability1key) && !isAbility1Cooldown)
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;
        }
        if (Input.GetKeyDown(ability2key) && !isAbility2Cooldown)
        {
            isAbility2Cooldown = true;
            currentAbility2Cooldown = ability2Cooldown;
        }
        if (Input.GetKeyDown(ability3key) && !isAbility3Cooldown)
        {
            isAbility3Cooldown = true;
            currentAbility3Cooldown = ability3Cooldown;
        }
        if (Input.GetKeyDown(ability4key) && !isAbility4Cooldown)
        {
            isAbility4Cooldown = true;
            currentAbility4Cooldown = ability4Cooldown;
        }
        if (Input.GetKeyDown(ability5key) && !isAbility5Cooldown)
        {
            isAbility5Cooldown = true;
            currentAbility5Cooldown = ability5Cooldown;
        }
    }

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if(isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if(currentCooldown <= 0f) {
                isCooldown = false;
                currentCooldown = 0f;
                if(skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if(skillText != null)
                {
                    skillText.text = "";
                }
             }
            else
            {
                if (skillImage != null) {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if(skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
