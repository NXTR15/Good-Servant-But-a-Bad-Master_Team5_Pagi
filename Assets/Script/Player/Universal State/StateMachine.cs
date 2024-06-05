using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;

    // Update is called once per frame
    void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState(Time.deltaTime);
        }        
    }

    public void SwitchState(State newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState?.EnterState();        
    }
}
