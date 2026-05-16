using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    public int maxHealth = 300;
    public Image healthBar;
    public float KnockBackForce = 5f;
    public Transform player;
    public float detectRange = 5f;
    public float attackRange = 4f;
    public float speed = 1.5f;
    public int damage1 = 20;
    public int damage2 = 50;
    public float attackCooldown = 3.5f;
    public GameObject attackHitbox;
    

    private int currentHealth;
    private Rigidbody2D rb;
    private float lastAttackTime;
    Animator animator;
    


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        if(healthBar != null)
        {
            healthBar.fillAmount = 1f;
        }
        
    }

    void Update()
    {
       if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < detectRange)
        {
            if (distance > attackRange)
            {
                animator.SetBool("isWalking", true);
                MoveToPlayer();
            }
            else
            {
                animator.SetBool("isWalking", false);
                AttackPlayer();
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        } 
    }
    
    public void TakeDamage(int damage, Transform attacker)
    {
        currentHealth -= damage;
        healthBar.fillAmount = (float)currentHealth / maxHealth;

        Vector2 direction = (transform.position - attacker.position).normalized;
        rb.AddForce(new Vector2(direction.x, 0.5f)  * KnockBackForce, ForceMode2D.Impulse);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("dead");
            Invoke("WinGame", 1.5f);
        }
    }

    void MoveToPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        Vector3 scale = transform.localScale;

        if (direction.x > 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
        
    }

    void AttackPlayer()
    {
       if (Time.time - lastAttackTime > attackCooldown)
    {
        float rand = Random.value;

        if (rand < 0.7f) 
        {
            animator.SetTrigger("attack2");
        }
        else 
        {
            animator.SetTrigger("attack1");
        }

        lastAttackTime = Time.time;
    }
    }

    public void EnableHitbox()
    {
        attackHitbox.SetActive(true);
    }

     public void DealDamage1()
    {
        float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= attackRange)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damage1);
                    }
            }       
    }

    public void DealDamage2()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage2);
                }
        }
    }

    public void DisableHitbox()
    {
        attackHitbox.SetActive(false);
    }

    void WinGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("GameWin"); 
    }

    
}
