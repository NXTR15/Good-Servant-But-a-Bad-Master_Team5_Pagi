using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public float transitionTime = 1f;

    // Transition to the next scene
    public void TransitionToNextScene()
    {
        StartCoroutine(LoadNextScene());
    }

    // Transition to a specific scene by name
    public void TransitionToSpecificScene(string sceneName)
    {
        StartCoroutine(LoadSpecificScene(sceneName));
    }

    // Coroutine to load the next scene
    private IEnumerator LoadNextScene()
    {
        // Placeholder for fade-out animation if needed
        yield return new WaitForSeconds(transitionTime);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);

        // Placeholder for fade-in animation if needed
    }

    // Coroutine to load a specific scene by name
    private IEnumerator LoadSpecificScene(string sceneName)
    {
        // Placeholder for fade-out animation if needed
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);

        // Placeholder for fade-in animation if needed
    }
}
