using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerHealth : MonoBehaviour
{
    public Health health;
    public Timer Timer;
    private Scene scene;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();        
    }

    // Update is called once per frame
    void Update()
    {
        if (health.HealthCount <= 0)
        {
            Invoke("RestartScene", 1f);
        }
    }

    private void RestartScene()
    {      
        SceneManager.LoadScene(scene.name);
    }


}
