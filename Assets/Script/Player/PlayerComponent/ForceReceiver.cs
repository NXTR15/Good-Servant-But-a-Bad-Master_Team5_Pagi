using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private float KnockbackStrength;
    private Rigidbody2D rigidBody2D;
    private GameObject attackingPlayer;
    private StateMachine stateMachine;

    private void Awake()
    {
        attackingPlayer = GameObject.FindGameObjectWithTag("AttackingPlayer");
        rigidBody2D = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<PlayerStateMachine>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == attackingPlayer)
        {
            StartCoroutine(KnockBack());
        }
    }

    IEnumerator KnockBack()
    {
        yield return null;
        stateMachine.enabled = false;
        yield return null;
        Vector2 direction = (this.transform.position - attackingPlayer.transform.position).normalized;
        rigidBody2D.AddForce(direction * this.KnockbackStrength, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        stateMachine.enabled = true;
    }
}
