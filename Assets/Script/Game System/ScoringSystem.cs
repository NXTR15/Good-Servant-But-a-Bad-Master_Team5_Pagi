using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private GameObject ball;
    private Animator HeroineAnimator;
    public float score {get; private set;}

    public void LoadData(GameData data)
    {
        this.score = data.ScoreInMinigames;
    }

    public void SaveData(ref GameData data)
    {
        data.ScoreInMinigames = this.score;
    }

    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        HeroineAnimator = GameObject.FindGameObjectWithTag("Heroine").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        Debug.Log(score);
        StartCoroutine(HeroineExpressionChange());
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
