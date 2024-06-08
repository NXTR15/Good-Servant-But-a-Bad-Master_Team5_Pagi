using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue {  get; private set; }
    public event Action HideEvent;
    public event Action DodgeEvent;

    private Controls controls;

    // Start is called before the first frame update
    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls?.Player.Disable();
    }

    public void OnHide(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            HideEvent?.Invoke();
        }
        return;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DodgeEvent?.Invoke();
        }
        return;
    }
}
