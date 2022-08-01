using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    public static GameState currentGameState {get; private set; }

    public static event Action<GameState> OnGameStateChanged;

    public static void SetGameState(GameState newGameState){
        if(newGameState == currentGameState){
            return;
        }

        currentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }
}
