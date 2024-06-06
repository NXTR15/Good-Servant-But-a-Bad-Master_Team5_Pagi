using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D currentBallRigidbody;
    private Camera m_Camera;
    private Vector3 mousePos;
    private void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if(!Input.GetMouseButton(0) && currentBallRigidbody != null)
        {
            currentBallRigidbody.isKinematic = false;
            return;
        }

        if(currentBallRigidbody != null)
        {
            currentBallRigidbody.isKinematic = true;
        }
              
        mousePos = m_Camera.ScreenToWorldPoint(Input.mousePosition);

        if(currentBallRigidbody != null)
        {
            currentBallRigidbody.position = mousePos;
        }
            
    }
}
