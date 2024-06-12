using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private float KnockbackStrength;
    private Rigidbody2D rigidBody2D;
    public GameObject attackingPlayer;
    private StateMachine stateMachine;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        attackingPlayer = GameObject.FindGameObjectWithTag("AttackingPlayer");
        rigidBody2D = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<PlayerStateMachine>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackingPlayer"))
        {
            Debug.Log("Player get attacked");
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
        yield return null;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        stateMachine.enabled = true;
        spriteRenderer.color = Color.white;
    }
}
