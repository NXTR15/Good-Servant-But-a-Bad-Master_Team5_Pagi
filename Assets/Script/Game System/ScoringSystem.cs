using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private GameObject ball;
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        Debug.Log(score);       
    }
    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
