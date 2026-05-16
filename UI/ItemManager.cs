using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public int healPotion = 5;
    public int staminaPotion = 5;
    public TextMeshProUGUI healText;
    public TextMeshProUGUI staminaText;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseHealPotion();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UseStaminaPotion();
        }
    }

    void UseHealPotion()
    {
        if (healPotion > 0)
        {
            healPotion--;
            UpdateUI();
        }
    }

    void UseStaminaPotion()
    {
        if (staminaPotion > 0)
        {
            staminaPotion--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        healText.text = healPotion.ToString();
        staminaText.text = staminaPotion.ToString();
    }
}

