using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameCS : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    private bool isGamePaused = false;

    private void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isGamePaused)
        {
            Debug.Log("Game Paused");
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
            isGamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && isGamePaused)
        {
            Debug.Log("Game Resumed");
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
            isGamePaused = false;
        }
    }
}
