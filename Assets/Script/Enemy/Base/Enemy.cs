using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable, IEnemyMovable, ITriggerCheckable
{
    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepSound
    }

    [field: SerializeField] public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Rigidbody2D rb { get; set; }
    public Animator animator { get; set; }
    public bool IsFacingRight { get; set; } = false;
    public bool isAggroPlayer { get; set; }
    public bool isAttackRangeCheck { get; set; }

    #region StateMachine variables
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyPatrolState PatrolState { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    
    #endregion


    #region Patrol Variables
    public GameObject PointA;
    public GameObject PointB;
    public float Speed;
    #endregion

    #region Chase Variables
    public float ChaseSpeed;
    #endregion


    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        PatrolState = new EnemyPatrolState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
    }

    private void AnimTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimTriggerEvent(triggerType);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StateMachine.Initialize(PatrolState);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector2 velocity)
    {
        rb.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }

        else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    #region Distance Check
    public void SetAggroStatus(bool IsAggroPlayer)
    {
        isAggroPlayer = IsAggroPlayer;
    }

    public void SetAttackCheck(bool IsAttackCheck)
    {
        isAttackRangeCheck = IsAttackCheck;
    }
    #endregion
}
