using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private GameObject player;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && player != null)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
        return;
    }

    public void ToGameplay()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(sceneName);
    }
}
