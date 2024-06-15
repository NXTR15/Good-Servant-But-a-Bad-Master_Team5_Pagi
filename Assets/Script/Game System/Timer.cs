using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour, IDataPersistence
{
    [SerializeField] private ScoringSystem scoreSystem;
    [SerializeField] private TextMeshProUGUI timerText;   
    [SerializeField] private string WinSceneName;
    [SerializeField] private string LoseSceneName;
    [SerializeField] private string TimeoutSceneName;

    public float remainingTime;

    public void LoadData(GameData data)
    {
        this.remainingTime = data.TimeRemaining;
    }

    public void SaveData(GameData data)
    {
        data.TimeRemaining = this.remainingTime;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;            
        }
        else if (remainingTime <= 0)
        {           
            remainingTime = 0;
            DataPersistenceManager.instance.NewGame();
            SceneManager.LoadScene(TimeoutSceneName);
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
    
}
