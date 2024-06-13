using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    private bool isGamePaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isGamePaused)
        {
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
            isGamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && isGamePaused)
        {
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
            isGamePaused = false;
        }
    }
}
