using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerBasketball : MonoBehaviour
{
    [SerializeField] private ScoringSystem scoreSystem;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private string WinSceneName;
    [SerializeField] private string LoseSceneName;
    [SerializeField] private float transitionTime = 2f;

    [SerializeField] private GameObject winAnimatorObject; // GameObject containing Win Animator
    [SerializeField] private GameObject loseAnimatorObject; // GameObject containing Lose Animator
    [SerializeField] private Animator winAnimator; // Animator for Win
    [SerializeField] private Animator loseAnimator; // Animator for Lose

    private bool isCoroutineRunning = false;

    public float timer;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0 && !isCoroutineRunning)
        {
            timer = 0;

            if (scoreSystem?.score >= 5)
            {
                StartCoroutine(HandleEndGame(winAnimatorObject, winAnimator, "EndWin", WinSceneName));
            }
            else if (scoreSystem?.score < 5)
            {
                StartCoroutine(HandleEndGame(loseAnimatorObject, loseAnimator, "EndLose", LoseSceneName));
            }
        }
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator HandleEndGame(GameObject animatorObject, Animator animator, string triggerName, string sceneName)
    {
        isCoroutineRunning = true;

        Debug.Log("Activating animator object: " + animatorObject.name);
        animatorObject.SetActive(true); // Activate the GameObject containing the Animator

        Debug.Log("Setting trigger '" + triggerName + "' for animator: " + animator.name);
        animator.SetTrigger(triggerName); // Trigger the appropriate End animation

        yield return new WaitForSeconds(transitionTime); // Wait for the transition animation to finish

        Debug.Log("Transition time finished. Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);

        isCoroutineRunning = false;
    }
}
