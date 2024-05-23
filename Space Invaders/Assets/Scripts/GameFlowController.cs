
using System;
using UnityEngine;

public class GameFlowController 
{
    private GameFlowModel m_gameFlowModel;
    
    private PlayerModel m_playerModel;

    //evento disparado qdo entramos em um estado novo
    public Action<GameState> StateEnter = default;
    //evento disparado qdo saimos de um estado
    public Action<GameState> StateExit = default;

    //recebe playerModel como referencia
    public GameFlowController(PlayerModel playerModel)
    {
        m_playerModel = playerModel;
        m_gameFlowModel = new GameFlowModel();
    }

    public void UpdateCurrentState()
    {
        switch (m_gameFlowModel.GameState)
        {
            case GameState.MainMenu:
                MainMenuUpdate();
                break;
            case GameState.Paused:
                PausedUpdate();
                break;
            case GameState.Playing:
                PlayingUpdate();
                break;
            case GameState.GameOverScreen:
                //GameOverScreenUpdate();
                break;
        }
    }
    public void ChangeState(GameState newState)
    {
        if (newState != m_gameFlowModel.GameState)
        {
            switch (m_gameFlowModel.GameState)
            {
                case GameState.MainMenu:
                    ExitMainMenu();
                    break;
                case GameState.Paused:
                    ExitPaused();
                    break;
                case GameState.Playing:
                    ExitPlaying();
                    break;
                case GameState.GameOverScreen:
                    //ExitGameOverScreen();
                    break;
            }
            StateExit(m_gameFlowModel.GameState);

            switch (newState)
            {
                case GameState.MainMenu:
                    EnterMainMenu();
                    break;
                case GameState.Paused:
                    EnterPaused();
                    break;
                case GameState.Playing:
                    EnterPlaying();
                    break;
                case GameState.GameOverScreen:
                    //EnterGameOverScreen();
                    break;
            }
            StateEnter(newState);

            m_gameFlowModel.GameState = newState;
        }
    }

    //??
    public GameState GameState => m_gameFlowModel.GameState;

    private void EnterMainMenu()
    {
        // Implementação da lógica de entrada no menu principal
    }
    private void MainMenuUpdate()
    {
        // Implementação da lógica de atualização do menu principal
    }
    private void ExitMainMenu()
    {
        // Implementação da lógica de saída do menu principal
    }


    private void EnterPlaying()
    {
        // Implementação da lógica de entrada no estado de jogo
    }

    private void PlayingUpdate()
    {
        if(!m_playerModel.IsEntityAlive)
        {
            ChangeState(GameState.GameOverScreen);
        }
    }

    private void ExitPlaying()
    {
        // Implementação da lógica de saída do estado de jogo
    }

    private void EnterPaused()
    {
        Time.timeScale = 0f; // Pausar o tempo do jogo
    }

    private void PausedUpdate()
    {
        // Implementação da lógica de atualização do estado de pausa (se necessário)
    }

    private void ExitPaused()
    {
        Time.timeScale = 1f; // Retomar o tempo do jogo
    }

}