using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderView : EntityView, IDamageReceiver
{
    [SerializeField]
    private ShipController m_shipController = new ShipController();
    [SerializeField]
    private EntityModel m_model = new EntityModel(); //invaderView declara o seu proprio model
    public void ReceiveCommands(List <ShipCommand> commands) { }

    public void ReceiveDamage()
    {
        m_shipController.NotifyDamageReceived();
    }

    protected override EntityModel GetModel()
    {
        return m_model; //retorna o override criado na classe
    }

    protected override EntityController GetController()
    {
        return m_shipController;
    }
}
