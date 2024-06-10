using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private Health playerHealthComponent;
    [SerializeField] private GameObject HealthFull1;
    [SerializeField] private GameObject HealthFull2;
    [SerializeField] private GameObject HealthFull3;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthComponent.HealthCount == 20)
        {
            HealthFull1.SetActive(false);
        }
        else if (playerHealthComponent.HealthCount == 10)
        {
            HealthFull2.SetActive(false);
        }
        else if (playerHealthComponent.HealthCount == 0)
        {
            HealthFull3.SetActive(false);
        }
    }
}
