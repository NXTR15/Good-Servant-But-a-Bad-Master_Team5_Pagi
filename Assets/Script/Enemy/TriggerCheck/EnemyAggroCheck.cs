using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroCheck : MonoBehaviour
{
    public GameObject playerTarget { get; set; }
    private Enemy enemy;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == playerTarget)
        {
            enemy.SetAggroStatus(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerTarget)
        {
            enemy.SetAggroStatus(false);
        }
    }
}
