using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; 
    [SerializeField] private float DelayDuration;
    [SerializeField] private float RespawnDelay;

    private Rigidbody2D pivot;
    private Camera m_Camera;
    private Vector3 mousePos;
    private bool isDragging;
    private Rigidbody2D currentBallRigidbody;
    private SpringJoint2D currentBallSpringJoint;
    private void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        pivot = GameObject.FindGameObjectWithTag("PivotPoint").GetComponent<Rigidbody2D>();

        SpawnNewBall();
    }

    private void Update()
    {
        if(currentBallRigidbody == null) { return; }
        if(pivot == null) { return; }

        if (!Input.GetMouseButton(0))
        {
            if(isDragging)
            {
                StartCoroutine(LaunchBall());
            }
            isDragging = false;
            
            return;
        }

        isDragging = true;

        currentBallRigidbody.isKinematic = true;
              
        mousePos = m_Camera.ScreenToWorldPoint(Input.mousePosition);

        currentBallRigidbody.position = mousePos;                  
    }

    private void SpawnNewBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
        currentBallRigidbody = ballInstance.GetComponent<Rigidbody2D>();
        currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();

        currentBallSpringJoint.connectedBody = pivot;
    }

    IEnumerator LaunchBall()
    {
        currentBallRigidbody.isKinematic = false;
        currentBallRigidbody = null;

        yield return new WaitForSeconds(DelayDuration);

        currentBallSpringJoint.enabled = false;
        currentBallSpringJoint = null;

        yield return new WaitForSeconds(RespawnDelay);

        SpawnNewBall();
    }
}
