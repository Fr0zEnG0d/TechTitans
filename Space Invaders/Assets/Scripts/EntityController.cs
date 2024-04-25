using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EntityController
{
    private EntityModel m_model;
    [SerializeField] private float m_speed;


    public void InitializeEntityController(EntityModel model) 
    { 
        m_model = model;
    }
    

    public void ReceiveCommandsList(List <ShipCommand> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i] == ShipCommand.Shoot)
            {
                Shoot();
            }
            else
            {
                ChangeModelPosition(commands[i]);
            }
                 
        }
    }

    private void ChangeModelPosition(ShipCommand command) {
        Vector2 position = m_model.Position;
        switch (command)
        {
            case ShipCommand.MoveLeft:
                position.x += (-m_speed) * Time.deltaTime;
                break;
            case ShipCommand.MoveRight:
                position.x += m_speed * Time.deltaTime;
                break;
        }
        m_model.Position = position; //aqui o controller altera o model

    }
    private void Shoot() {
        Debug.Log("SHOOT!!!"); //Debug,log apenas para testar o botao do mouse
    }

    virtual public void NotifyDamageReceived() {
        m_model.IsEntityAlive = false; 
    }
}
