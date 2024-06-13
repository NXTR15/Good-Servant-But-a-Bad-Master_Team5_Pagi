using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadButton : MonoBehaviour
{
    public void SaveClick()
    {
        DataPersistenceManager.instance.SaveGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
