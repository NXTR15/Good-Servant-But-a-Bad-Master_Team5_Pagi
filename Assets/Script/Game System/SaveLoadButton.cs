using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadButton : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;

    public void SaveClick()
    {
        DataPersistenceManager.instance.SaveGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        Debug.Log("Game Resumed from Pause Panel");
    }
}
