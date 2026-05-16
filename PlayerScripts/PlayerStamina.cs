using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public Image PlayerStaminaBar;
    public float maxStamina = 100f;
    public float stamina;
    public float regenSpeed = 2f;

    void Start()
    {
        stamina = maxStamina;
    }

    void Update()
    {
        RegenStamina();
    }

    void RegenStamina()
    {
        if (stamina < maxStamina)
        {
            stamina += regenSpeed * Time.deltaTime;

            if (stamina > maxStamina)
                stamina = maxStamina;

            PlayerStaminaBar.fillAmount = stamina / maxStamina;
        }
    }

    public bool UseStamina(float amount)
    {
        if (stamina >= amount)
        {
            stamina -= amount;
            PlayerStaminaBar.fillAmount = stamina / maxStamina;
            return true;
        }

        return false;
    }

    public void RestoreStamina(float amount)
    {
        stamina += amount;

        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }

        PlayerStaminaBar.fillAmount = stamina / maxStamina;
    }
}
