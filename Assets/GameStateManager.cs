using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameState gameState = GameState.Gameplay;

    public void ResumeGameState()
    {
        gameState = GameState.Gameplay;
    }
    public void PauseGameState()
    {
        gameState = GameState.Paused;
    }
}

[System.Serializable]
public enum GameState
{
    Gameplay,
    Paused
}