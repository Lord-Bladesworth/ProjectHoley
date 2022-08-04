using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _Instance;
    PlayerData player;

    public static ScoreManager instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new GameObject("Score Manager").AddComponent<ScoreManager>();
            }
            return _Instance;
        }
    }
    void InitializeSession()
    {
        if (player == null)
            player = new PlayerData();
    }
    void LogNewPlayer(string name)
    {

    }
    //modify later to consider multiplayer
    void SetPlayer(string name, int PlayerIndex = 0)
    {
        player.playerName = name;
    }
    public static void ReceieveScore(int Score, int PlayerIndex = 0)
    {

    }

    class SessionData
    {
        public int BoxesRemaining; 
        public float TimeRemaining;
    }
    //player data
    class PlayerData
    {
        public string playerName;
        public int playerScore;
    }
}
