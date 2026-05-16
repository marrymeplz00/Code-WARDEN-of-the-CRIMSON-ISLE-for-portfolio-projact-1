using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject swordHitbox;
    public Animator animator;
    PlayerStamina stamina;

    bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        swordHitbox.SetActive(false);
        stamina = GetComponent<PlayerStamina>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            if (stamina.UseStamina(20))
            {
            animator.SetTrigger("attack");
            isAttacking = true;
            }
        }
    }

    public void EnableHitbox()
    {
        swordHitbox.SetActive(true);
    }

    public void DisableHitbox()
    {
        swordHitbox.SetActive(false);
        isAttacking = false;
    }
    
}
