using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerImpactState : PlayerBaseState
{
    private float duration = 1f;
    
    public PlayerImpactState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState(float deltaTime)
    {
        duration -= deltaTime;

        if (duration <= 0f)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
    }

    public override void ExitState()
    {
        
    }
}
