using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int damage = 15;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

    if (collision.CompareTag("Enemy"))
    {
        NormalEnemy normalEnemy = collision.GetComponent<NormalEnemy>();
        if (normalEnemy != null)
        {
            normalEnemy.TakeDamage(damage, transform);
        }

        BossEnemy boosEnemy = collision.GetComponent<BossEnemy>();
        if (boosEnemy != null)
        {
            boosEnemy.TakeDamage(damage, transform);
        }
    
    }
    
    }
}
