using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image PlayerHealthBar;
    public int maxHealth = 100;
    public int health;
     Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        
        health -= damage;
        PlayerHealthBar.fillAmount = (float)health / maxHealth;
        
        if (health <= 0)
        {
            animator.SetTrigger("dead");
            Invoke("LoadLoseScene", 1.5f);
        }
    }

    public void Heal(int amount)
    {
    health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

    PlayerHealthBar.fillAmount = (float)health / maxHealth;
    }

    void LoadLoseScene()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver"); 
    }
}
