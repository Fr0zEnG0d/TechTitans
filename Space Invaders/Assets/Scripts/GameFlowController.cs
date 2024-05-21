
using System;


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
                //PausedUpdate();
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
                    //ExitPaused();
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
                    //EnterPaused();
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

    
    private void EnterMainMenu()
    {
        
    }
    private void MainMenuUpdate()
    {

    }
    private void ExitMainMenu()
    {
    }


    private void EnterPlaying()
    {

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

    }
    
}