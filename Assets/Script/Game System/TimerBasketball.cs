using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerBasketball : MonoBehaviour
{
    [SerializeField] private ScoringSystem scoreSystem;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private string WinSceneName;
    [SerializeField] private string LoseSceneName;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            timer = 0;

            if (scoreSystem?.score >= 5)
            {
                SceneManager.LoadScene(WinSceneName);
            }
            else if (scoreSystem?.score < 5)
            {
                SceneManager.LoadScene(LoseSceneName);
            }
        }
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
