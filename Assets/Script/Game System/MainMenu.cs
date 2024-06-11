using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button NewGameButton;
    [SerializeField] private Button LoadGameButton;


    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            LoadGameButton.interactable = false;
        }
    }

    public void NewGameClick()
    {
        DisableMenuButton();
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("CityArea");
    }

    public void ContinueClick()
    {
        DisableMenuButton();
        //DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("MainArea");
    }

    private void DisableMenuButton()
    {
        NewGameButton.interactable = false;
        LoadGameButton.interactable = false;
    }
}
