using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Idle State Active");
        stateMachine.SpriteRenderer.flipX = false;
    }

    public override void UpdateState(float deltaTime)
    {
        
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {          
            stateMachine.Animator.SetBool("IsMove", false);
            return;
        }

        stateMachine.SwitchState(new PlayerMovementState(stateMachine));
        stateMachine.Animator.SetBool("IsMove", true);
    }

    public override void ExitState()
    {
        
    }   
}
