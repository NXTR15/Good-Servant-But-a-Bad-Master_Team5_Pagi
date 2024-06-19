using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionMainMenu : MonoBehaviour
{
    public float transitionTime = 2f;

    // Transition to the next scene
    public void TransitionToNextScene()
    {
        Debug.Log("TransitionToNextScene called");
        StartCoroutine(LoadNextScene());
    }

    // Transition to a specific scene by name
    public void TransitionToSpecificScene(string sceneName)
    {
        Debug.Log("TransitionToSpecificScene called with scene: " + sceneName);
        StartCoroutine(LoadSpecificScene(sceneName));
    }

    // Coroutine to load the next scene
    private IEnumerator LoadNextScene()
    {
        Debug.Log("Waiting for " + transitionTime + " seconds before loading the next scene.");
        yield return new WaitForSecondsRealtime(transitionTime); // Use WaitForSecondsRealtime if Time.timeScale is 0
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Loading next scene with index: " + nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Coroutine to load a specific scene by name
    private IEnumerator LoadSpecificScene(string sceneName)
    {
        Debug.Log("Waiting for " + transitionTime + " seconds before loading the specific scene: " + sceneName);
        yield return new WaitForSeconds(transitionTime); // Wait for transition time
        Debug.Log("Loading specific scene: " + sceneName);
        SceneManager.LoadScene(sceneName); // Load the specified scene
    }
}
