using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float HealthCount;
    [SerializeField] private float DamageCount;
    private ForceReceiver forceReceiver;

    private void Awake()
    {
        forceReceiver = GetComponent<ForceReceiver>();
    }

    private void Update()
    {
        if (HealthCount <= 0) 
        {
            Destroy(this.gameObject);
        }
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == forceReceiver.attackingPlayer)
        {
            Debug.Log("Player Health decreased");
            HealthCount -= DamageCount;
        }
    }
}
