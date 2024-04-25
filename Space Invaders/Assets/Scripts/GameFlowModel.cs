using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{ MainMenu, Paused, Playing, GameOverScreen }
public class GameFlowModel
{
    private GameState m_gameState;
    private int m_gameScore = 0;

    public GameState GameState { 
        get { 
            return m_gameState; 
        } 
        set { 
            m_gameState = value; 
        } 
    }
    
    public int GameScore
    {
        get {
            return m_gameScore;
        }
        set {
            m_gameScore = value;
        }
    }

}
