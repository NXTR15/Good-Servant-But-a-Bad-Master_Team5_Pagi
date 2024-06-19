using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadWithSceneCheck : MonoBehaviour
{
    public string sceneToDestroy; // Nama scene di mana objek ini akan dihancurkan

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Jangan hancurkan objek ini saat berganti scene
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Berlangganan event saat scene baru dimuat
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Batalkan langganan event saat objek dinonaktifkan
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Periksa jika nama scene yang aktif sama dengan sceneToDestroy
        if (scene.name == sceneToDestroy)
        {
            Destroy(gameObject); // Hancurkan objek ini
        }
    }
}
