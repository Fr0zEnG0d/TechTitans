using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameFlowView : MonoBehaviour
{
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI ScoreText;
    public PlayerView PlayerView;
    private PlayerModel m_playerModel;

    // Start is called before the first frame update
    void Start()
    {
        m_playerModel = PlayerView.PlayerModel; //inicializa player model
        RefreshLivesText();
        PlayerView.OnPlayerReceivedDamage += OnPlayerTookDamage; //Toda vez que o player tomar dano, o GameFlow sera avisado
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
