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
    public float startDelay = 2f; // Duration to wait before starting

    void Start()
    {
        nextButton.SetActive(false); // Hide the next button initially
        if (bottomBar != null)
        {
            bottomBar.gameObject.SetActive(false); // Hide the BottomBar initially
        }
        if (backgroundController != null)
        {
            backgroundController.gameObject.SetActive(false); // Hide the BackgroundController initially
        }
        StartCoroutine(StartWithDelay());
    }

    private IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(startDelay); // Wait for the specified delay
        UpdateScene(currentScene); // Continue with the usual Start logic
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
        bool hasSentences = scene.sentences.Count > 0;
        bool hasBackground = scene.background != null;

        if (bottomBar != null)
        {
            bottomBar.gameObject.SetActive(hasSentences); // Show/Hide the BottomBar based on sentences
            if (hasSentences)
            {
                bottomBar.PlayScene(scene);
            }
        }

        if (backgroundController != null)
        {
            backgroundController.gameObject.SetActive(hasBackground); // Show/Hide the BackgroundController based on background
            if (hasBackground)
            {
                backgroundController.SwitchBackground(scene.background, scene.backgroundPosition);
            }
        }
    }
}
