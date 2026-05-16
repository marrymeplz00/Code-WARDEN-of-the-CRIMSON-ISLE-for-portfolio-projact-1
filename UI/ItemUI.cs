using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemUI : MonoBehaviour
{
    
    public TextMeshProUGUI healText;
    public TextMeshProUGUI staminaText;

    public int healPotion = 5;
    public int staminaPotion = 5;

    void Update()
    {
        healText.text = healPotion.ToString();
        staminaText.text = staminaPotion.ToString();
    }
}
