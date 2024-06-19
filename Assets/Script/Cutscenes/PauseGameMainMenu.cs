using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    private bool isGamePaused = false;

    private void Start()
    {
        PausePanel.SetActive(false);
    }

    public void TogglePause()
    {
        if (!isGamePaused)
        {
            Debug.Log("Game Paused");
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
            isGamePaused = true;
        }
        else
        {
            Debug.Log("Game Resumed");
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
            isGamePaused = false;
        }
        Debug.Log("Time.timeScale: " + Time.timeScale);
    }

    public void ClosePanel()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }
}
