using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : EntityView
{

    [SerializeField]
    private PlayerModel m_playerModel = new PlayerModel();
    public PlayerModel PlayerModel {  get { return m_playerModel; } }

    public delegate void PlayerReceivedDamage(); //assinatura do evento
    public event PlayerReceivedDamage OnPlayerReceivedDamage;

   //Metodo recebe comandos do User e adiciona-os na lista
   public void ReadInputFromUser(List<ShipCommand> outCommands) {
        if (Input.GetKey(KeyCode.A))
        {
            outCommands.Add(ShipCommand.MoveLeft);
        }
        if(Input.GetKey(KeyCode.D))
        {
            outCommands.Add(ShipCommand.MoveRight);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            outCommands.Add(ShipCommand.Shoot);
            //Debug.Log("Mouse button pressed");
        }
    }

    

    protected override void BeforeUpdate() //implementacao especifica para o Player
    {
        ReadInputFromUser(m_commands);
    }

    protected override EntityModel GetModel()
    {
        return m_playerModel;
    }

    public override void ReceiveDamage()
    {
        base.ReceiveDamage(); //chama a implementacao da classe base (EntityView)
        OnPlayerReceivedDamage.Invoke(); //toda vez que dispara o evento, comunica que recebeu dano
    }
}
