using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    private GameObject ball;
    private float score;

    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        Debug.Log(score);       
    }
}
