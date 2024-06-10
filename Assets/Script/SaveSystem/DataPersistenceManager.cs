using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Development Debug")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Config")]
    [SerializeField] private string fileName;

    [Header("Autosave Config")]
    [SerializeField] private float autoSaveTimer;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    private Coroutine autoSaveCoroutine;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {       
        if (instance != null)
        {
            Debug.LogError("Set 1 only DataPersistenceManager in scene. Destroy new one");
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("SceneLoaded Called");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();

        if(autoSaveCoroutine != null)
        {
            StopCoroutine(autoSaveCoroutine);
        }
        autoSaveCoroutine = StartCoroutine(AutoSave());
    }

   public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        //Load any data using data handler
        this.gameData = dataHandler.Load();

        //start new game if null and configure using debug bool
        if (this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        //if no data was found, get to new game
        if (this.gameData == null)
        {
            Debug.Log("No data found. Please start a new game");
            return;
        }
        //Push loaded data to script that needed it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded remaining time = " + gameData.TimeRemaining);
    }
    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.LogWarning("No save data was found. Please start a new game");
            return;
        }

        //pass data to other script
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        //save data using data handler
        dataHandler.Save(gameData);

        Debug.Log("Saved remaining time = " + gameData.TimeRemaining);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = 
            FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }

    private IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoSaveTimer);
            SaveGame();
            Debug.Log("Autosave Initiated");
        }
    }
}
