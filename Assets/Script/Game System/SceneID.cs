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
}
