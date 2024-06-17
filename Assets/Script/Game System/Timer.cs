using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour, IDataPersistence
{
    [SerializeField] private ScoringSystem scoreSystem;
    [SerializeField] private TextMeshProUGUI timerText;   
    [SerializeField] private string WinSceneName;
    [SerializeField] private string LoseSceneName;
    [SerializeField] private string TimeoutSceneName;
    [SerializeField] private float timerToNextScene;
    [SerializeField] private float transitionTime = 2f;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Lose;
            
    private bool isCoroutineRunning = false;

    public float remainingTime;

    public void LoadData(GameData data)
    {
        this.remainingTime = data.TimeRemaining;
    }

    public void SaveData(GameData data)
    {
        data.TimeRemaining = this.remainingTime;
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0 && !isCoroutineRunning)
        {
            remainingTime = 0;
            StartCoroutine(HandleTimeout());
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator HandleTimeout()
    {
        isCoroutineRunning = true;
        DataPersistenceManager.instance.NewGame();
        Lose.SetActive(true);
        yield return new WaitForSeconds(timerToNextScene);
        animator.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(TimeoutSceneName);
    }

}
