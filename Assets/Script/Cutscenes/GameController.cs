using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    public GameObject nextButton;
    private bool reachedEnd = false;

    void Start()
    {
        nextButton.SetActive(false); // Hide the next button initially
        UpdateScene(currentScene);
    }

    void Update()
    {
        if (!reachedEnd && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (bottomBar == null || bottomBar.IsCompleted())
            {
                if (bottomBar != null && bottomBar.IsLastSentence())
                {
                    if (currentScene.nextScene != null)
                    {
                        currentScene = currentScene.nextScene;
                        UpdateScene(currentScene);
                    }
                    else
                    {
                        Debug.Log("Reached end of scenes.");
                        reachedEnd = true;
                        nextButton.SetActive(true); // Show the next button at the end
                    }
                }
                else if (bottomBar != null)
                {
                    bottomBar.PlayNextSentence();
                }
            }
        }
    }

    // Update the scene to the specified scene
    void UpdateScene(StoryScene scene)
    {
        if (scene.sentences.Count > 0)
        {
            if (bottomBar != null)
            {
                bottomBar.gameObject.SetActive(true);
                bottomBar.PlayScene(scene);
            }
        }
        else
        {
            if (bottomBar != null)
            {
                bottomBar.gameObject.SetActive(false);
            }
        }

        backgroundController.SwitchBackground(scene.background, scene.backgroundPosition);
    }
}