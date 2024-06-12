using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private GameObject ball;
    private Animator HeroineAnimator;
    public float score {get; private set;}

    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        HeroineAnimator = GameObject.FindGameObjectWithTag("Heroine").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            score++;
            Debug.Log(score);
            StartCoroutine(HeroineExpressionChange());
        }
    }
    private void Update()
    {
        scoreText.text = score.ToString();
    }

    IEnumerator HeroineExpressionChange()
    {
        HeroineAnimator.SetBool("isBallScore", true);
        yield return new WaitForSeconds(2f);
        HeroineAnimator.SetBool("isBallScore", false);
    }
}
