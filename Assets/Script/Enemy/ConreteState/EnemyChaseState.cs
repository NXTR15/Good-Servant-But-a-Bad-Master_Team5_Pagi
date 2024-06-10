using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private Transform playerTransform;    

    public override void AnimTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Enemy is Chasing");
        enemy.animator.SetBool("IsAttacking", false);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (!enemy.isAggroPlayer)
        {
            enemy.StateMachine.ChangeState(enemy.PatrolState);
        }

        if (enemy.isAttackRangeCheck)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }

        if (playerTransform != null)
        {
            Vector2 MoveDir = (playerTransform.position - enemy.transform.position).normalized;
            enemy.MoveEnemy(MoveDir * enemy.ChaseSpeed);
        }
        return;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
