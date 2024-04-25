using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderView : EntityView
{
    [SerializeField]
    private EntityModel m_model = new EntityModel(); //invaderView declara o seu proprio model
    public void ReceiveCommands(List <ShipCommand> commands) { }

    protected override EntityModel GetModel()
    {
        return m_model; //retorna o override criado na classe
    }
}
