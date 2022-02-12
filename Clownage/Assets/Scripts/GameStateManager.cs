using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private List<string> levels = new List<string>();
    [SerializeField] private string titleScreen;
    [SerializeField] private string endScreen;

    public static GameStateManager _instance;
    public static GAMESTATE gameState;

    public enum GAMESTATE
    {
        TITLE,
        PLAYING,
        GAMEOVER,
        SLOWDOWNTIME,
    }

    private void Awake()
    {
        //Check if the instance already exists, if not add this as the new instance, else destroy the current one
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public GAMESTATE getCurrentState()
    {
        return gameState;
    }
    
    public void SlowDownTime()
    {
        gameState = GAMESTATE.SLOWDOWNTIME;
    }

    public void ReturnToNormalTime()
    {
        gameState = GAMESTATE.PLAYING;
    }
}
