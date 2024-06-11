using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneID : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [SerializeField] private bool isSceneFinished = false;

    [ContextMenu("Generate GUID for id")]
    
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        throw new System.NotImplementedException();
    }

    public void SaveData(GameData data)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {

    }
}
