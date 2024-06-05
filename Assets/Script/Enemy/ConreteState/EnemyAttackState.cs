using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        
    }

    public override void AnimTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.animator.SetBool("IsAttacking", true);
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
        if (!enemy.isAttackRangeCheck)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        enemy.MoveEnemy(Vector2.zero);
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
