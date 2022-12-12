using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Hardware;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Instance ergreift die class des Codes
    public static GameStateManager Instance;

    public delegate void GameStateChangeDelegate(GameState targetState);
    // OnGameStateChanged wird zur Zusammenfassung des oberen Codes
    public event GameStateChangeDelegate OnGameStateChanged;
    
    public enum GameState
    {
        ready = 0,
        playing = 1,
        win = 2,
        lose = 3,
    }

    public GameState currentState;

    public GameState GetCurrentState()
    {
        return currentState;
    }

    public void SetCurrentState(GameState targetState)
    {
        currentState = targetState;

        if (OnGameStateChanged != null)
        {
            OnGameStateChanged?.Invoke(currentState);
        }
        
    }

    private void Awake()
    {
        // wenn keine andere Instance gefunden wird, wird diese Instance fixiert und nicht gelöscht
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // bei mehreren Instancen werden alle bis auf ersten bemerken, dass es den ersten Instance gibt und löschen sich
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetCurrentState(GameState.ready);
    }
}
