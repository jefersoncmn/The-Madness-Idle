using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            GameState currentGameState = GameStateManager.currentGameState;
            Debug.Log(""+currentGameState);
            GameState newGameState = currentGameState == GameState.Gameplay
                ?   GameState.Paused
                :   GameState.Gameplay;

            GameStateManager.SetGameState(newGameState);
        }
    }
}
