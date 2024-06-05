using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class EnemyPatrolState : EnemyState
{
    public EnemyPatrolState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    private Transform currentPoint;
    

    public override void AnimTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        currentPoint = enemy.PointA.transform;                   
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

        if(enemy.isAggroPlayer)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        Vector2 startingPoint = (currentPoint.position - enemy.transform.position).normalized;
        enemy.MoveEnemy(startingPoint * enemy.Speed);

        if (Vector2.Distance(enemy.transform.position, currentPoint.position) < 0.5f && currentPoint == enemy.PointA.transform)
        {
            
            currentPoint = enemy.PointB.transform;
        }
        if (Vector2.Distance(enemy.transform.position, currentPoint.position) < 0.5f && currentPoint == enemy.PointB.transform)
        {
            
            currentPoint = enemy.PointA.transform;
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(enemy.PointB.transform.position, 0.5f);
        Gizmos.DrawWireSphere(enemy.PointA.transform.position, 0.5f);
        Gizmos.DrawLine(enemy.PointB.transform.position, enemy.PointA.transform.position);
    }
}
