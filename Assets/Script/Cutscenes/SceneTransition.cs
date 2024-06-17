using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public float transitionTime = 2f;
    public Animator animator;
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
        animator.SetTrigger("End"); // Start end animation
        yield return new WaitForSecondsRealtime(transitionTime); // Use WaitForSecondsRealtime if Time.timeScale is 0
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        animator.SetTrigger("Start"); // Start fade-in animation in the next scene
    }

    // Coroutine to load a specific scene by name
    private IEnumerator LoadSpecificScene(string sceneName)
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime); // Wait for transition time
        SceneManager.LoadScene(sceneName); // Load the specified scene
        animator.SetTrigger("Start");
    }

}