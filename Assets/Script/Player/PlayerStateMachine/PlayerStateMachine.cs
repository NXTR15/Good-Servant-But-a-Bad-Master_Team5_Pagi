using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field:SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }


    [field: SerializeField] public float MoveSpeed { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        SwitchState(new PlayerIdleState(this));
    }
}
