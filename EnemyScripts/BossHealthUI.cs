using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject bossHealthUI;
    public Transform player;

    public float showDistance = 12f;

    void Start()
    {
        bossHealthUI.SetActive(false);
    }

    void Update()
    {
          
        float distance = Vector2.Distance(transform.position, player.position);
        bossHealthUI.SetActive(distance <= showDistance);
        if(distance <= showDistance)
        {
            bossHealthUI.SetActive(true);
        }
        else
        {
            bossHealthUI.SetActive(false);
        }
    }

}
