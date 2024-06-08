using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] private string SceneName;

    public void LoadData(GameData data)
    {
        this.remainingTime = data.TimeRemaining;
    }

    public void SaveData(ref GameData data)
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
            SceneManager.LoadScene(SceneName);
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
    
}
