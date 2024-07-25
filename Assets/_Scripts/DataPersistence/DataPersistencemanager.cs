using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataPersistencemanager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string FileName;

    [SerializeField] private GameObject player;
    
    private FileDataHandler dataHandler;
    
    public GameDataManager gameDataManager;
    public static DataPersistencemanager Instance { get; private set; }

    private void Awake()
    {              
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
        
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
        Debug.Log("OnSceneLoaded");
        LoadGame();        
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded");
        SaveGame();
    }
    public void NewGame()
    {
        dataHandler.DeleteJsonFile();
        this.gameDataManager = new GameDataManager();
    }

    public void LoadGame()
    {
        Debug.Log("LoadGamePersisRUn");
        GameData data = dataHandler.Load();
        Debug.Log("DataPersisData: "+ data);
        //load save data tu tap tin su dung data handler
        
            this.gameDataManager.gameData = data;
            Debug.Log("Data 1" + data);
            gameDataManager.LoadData();
        
        //if no data load => khoi tao new game
        if (this.gameDataManager.gameData == null)
        {
            Debug.Log("No data was found.Initialize data to defaults");
            NewGame();
        }       
    }


    public void SaveGame()
    {
        gameDataManager.SaveData();
        dataHandler.Save(gameDataManager.gameData);

    }

    public void OnApplicationQuit()
    {
        dataHandler.DeleteJsonFile();       
    }
}
