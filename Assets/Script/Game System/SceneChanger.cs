using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class SceneChanger : MonoBehaviour
{
    private GameObject player;
    public string sceneName;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private float timerToNextScene;
    [SerializeField] private float transitionTime;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && player != null)
        {
            StartCoroutine(LoadFinishScene());
        }
        return;
    }

    public void ToGameplay()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(sceneName);
    }

    private IEnumerator LoadFinishScene()
    {
        WinPanel.SetActive(true);
        yield return new WaitForSeconds(timerToNextScene);
        animator.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
