using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//UI
public class GameFlowView : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Hud; //UI q fica na tela enquanto joga, score e vidas

    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI ScoreText;

    public PlayerView PlayerView;
    private PlayerModel m_playerModel;

    private GameFlowController m_controller;

    // Start is called before the first frame update
    void Start()
    {
        m_playerModel = PlayerView.PlayerModel; //inicializa player model
        RefreshLivesText();
        PlayerView.OnPlayerReceivedDamage += OnPlayerTookDamage; //Toda vez que o player tomar dano, o GameFlow sera avisado

        m_controller = new GameFlowController(m_playerModel);
        m_controller.StateEnter += OnStateEnter;
        m_controller.StateExit += OnStateExit;

        SetInitialState();

        m_controller.ChangeState(GameState.MainMenu);
    }

    private void SetInitialState()
    {
        PlayerView.enabled = false;
        Hud.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_controller.UpdateCurrentState();
    }
    //Atualiza texto do numero de vidas baseado no player model
    private void RefreshLivesText()
    {
        LivesText.SetText(m_playerModel.Lives.ToString());
    }

    private void OnPlayerTookDamage() //toda vez que essa funcao for executada, um evento OnPlayerReceivedDamage foi disparado
    {
        RefreshLivesText();
    }

    private void OnStateExit(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                MainMenu.SetActive(false);
                break;
            case GameState.Paused:
                break;
            case GameState.Playing:
                Hud.SetActive(false);
                PlayerView.enabled = false;
                break;
            case GameState.GameOverScreen:
                break;
        }
    }

    private void OnStateEnter(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                MainMenu.SetActive(true);
                break;
            case GameState.Paused:
                break;
            case GameState.Playing:
                Hud.SetActive(true);
                PlayerView.enabled = true;
                break;
            case GameState.GameOverScreen:
                break;
        }
    }

    public void OnPlayButtonPressed()
    {
        m_controller.ChangeState(GameState.Playing);
    }

}
