using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    
    public PlayerMovementState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Move State Active");
    }

    public override void UpdateState(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = stateMachine.InputReader.MovementValue.y;
        movement.z = 0;
        stateMachine.Rigidbody2D.AddForce(movement * stateMachine.MoveSpeed * deltaTime);
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
        else if (stateMachine.InputReader.MovementValue == Vector2.up)
        {
            stateMachine.Animator.SetFloat("Horizontal", 0);
            stateMachine.Animator.SetFloat("Vertical", 1);
        }
        else if (stateMachine.InputReader.MovementValue == Vector2.down)
        {
            stateMachine.Animator.SetFloat("Horizontal", 0);
            stateMachine.Animator.SetFloat("Vertical", -1);
        }
        else if (stateMachine.InputReader.MovementValue == Vector2.right)
        {
            stateMachine.SpriteRenderer.flipX = true;
            stateMachine.Animator.SetFloat("Horizontal", 1);
            stateMachine.Animator.SetFloat("Vertical", 0);           
        }
        else if (stateMachine.InputReader.MovementValue == Vector2.left)
        {
            stateMachine.SpriteRenderer.flipX = false;
            stateMachine.Animator.SetFloat("Horizontal", -1);
            stateMachine.Animator.SetFloat("Vertical", 0);           
        }
    }

    public override void ExitState()
    {
        
    }
}
