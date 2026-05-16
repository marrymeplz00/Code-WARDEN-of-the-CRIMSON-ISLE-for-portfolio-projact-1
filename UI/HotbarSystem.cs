using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HotbarSystem : MonoBehaviour
{
    public int healPotion = 10;
    public int staminaPotion = 5;

    public TextMeshProUGUI healText;
    public TextMeshProUGUI staminaText;

    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;

    public GameObject swordObject; 

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            UseHealPotion();
        }

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseStaminaPotion();
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipSword();
        }
    }

    void UseHealPotion()
    {
        if (healPotion > 0)
        {
            healPotion--;
            playerHealth.Heal(25);
            UpdateUI();
        }
    }

    void UseStaminaPotion()
    {
        if (staminaPotion > 0)
        {
            staminaPotion--;
            playerStamina.RestoreStamina(25);
            UpdateUI();
        }
    }

    void EquipSword()
    {
        if (swordObject != null)
        {
            swordObject.SetActive(true);
            Debug.Log("Sword Equipped");
        }
    }

    void UpdateUI()
    {
        healText.text = healPotion.ToString();
        staminaText.text = staminaPotion.ToString();
    }
}
