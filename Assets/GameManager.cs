using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages the game, stores the object pool
public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    PlayerStartingData startingData;

    public static GameStateEnum GameState { get; private set; }
 
    [SerializeField]
    List<GameObject> objectPool;
    GameObject player;
    float FOVData;
    //seconds before a gameobject is set to disabled in seconds
    public static int TimetoDisable = 6;

   // public static GameManager Instance { get { return Instance; } private set { _instance = value; } }
    
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
                _instance.InitializeContainers();
              
            }
            return _instance;
        }
    }
  
    private void InitializeContainers()
    {
        objectPool = new List<GameObject>();
        Instance.startingData = new PlayerStartingData();
        GameState = GameStateEnum.Paused;
        
    }

    public static void SubscribeToPool(GameObject obj)
    {
        Instance.objectPool.Add(obj);
    }
    public static void SubscribePlayer(GameObject SubscribingPlayer,Vector3 StartingPosition, PlayerData Data)
    {
        Instance.player = SubscribingPlayer;
        Instance.startingData.PlayerInitialPosition = StartingPosition;
        Instance.startingData.PlayerInitialData = Data;
    }
    public static void SaveInitialFOV(float FOV)
    {
        Instance.FOVData = FOV;
    }
    public static void RestartGame()
    {
        GameState = GameStateEnum.Paused;
        for (int x=0; x< Instance.objectPool.Count;x++)
        {
            Instance.objectPool[x].GetComponent<BoxClass>().ResetGameObject();
        }
        Instance.player.GetComponent<PlayerClass>().PlayerRestart(Instance.startingData.PlayerInitialPosition,Instance.startingData.PlayerInitialData);
        Camera.main.fieldOfView = Instance.FOVData;
        GameObject.FindObjectOfType<CanvasManager>().gameObject.GetComponent<CanvasManager>().ReinitializeCanvas();
        
    }
    public static void PauseOrder()
    {
        GameState = GameStateEnum.Paused;
    }
    public static void ResumeOrder()
    {
        GameState = GameStateEnum.Running;
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
class PlayerStartingData
{
    public Vector3 PlayerInitialPosition;
    public PlayerData PlayerInitialData;
}