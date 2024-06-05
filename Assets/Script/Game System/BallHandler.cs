using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    private Camera m_Camera;
    private Vector3 mousePos;
    private void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        mousePos = m_Camera.ScreenToWorldPoint(Input.mousePosition);       

        Debug.Log(mousePos);
    }
}
