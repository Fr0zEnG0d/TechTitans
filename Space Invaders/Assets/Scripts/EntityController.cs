using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EntityController
{
    protected EntityModel m_model;
    [SerializeField] private float m_speed;

    protected GameObject m_entityGameObject;
    public void SetGameObject(GameObject gameObject)
    {
        m_entityGameObject = gameObject;
    }

    virtual public void InitializeEntityController(EntityModel model) 
    { 
        m_model = model;
    }
    

    public void ReceiveCommandsList(List <ShipCommand> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            ProcessCommand(commands[i]);
        }
    }

    protected virtual void ProcessCommand(ShipCommand command)
    {
        if (command != ShipCommand.Shoot)
        {
       
            ChangeModelPosition(command);
        }
    }

    private void ChangeModelPosition(ShipCommand command) {
        Vector2 position = m_model.Position;
        float maxposition = m_model.MaxPosition;
        switch (command)
        {
            case ShipCommand.MoveLeft:
                position.x += (-m_speed) * Time.deltaTime;
                break;
            case ShipCommand.MoveRight:
                position.x += m_speed * Time.deltaTime;
                break;
            case ShipCommand.MoveUp:
                position.y += m_speed * Time.deltaTime;
                break;
            case ShipCommand.MoveDown:
                position.y -= m_speed * Time.deltaTime;
                break;
        }
        
        // Limitar a posição máxima lateral
        position.x = Mathf.Clamp(position.x, -maxposition, maxposition); // "maxposition" é a posição mínima e máxima permitida

        // verificar posicao vertical e destruir se passar do limite da tela
        if (position.y > 30 || position.y < -20)
        {
            m_model.IsEntityAlive = false;
        }

        m_model.Position = position; // Aqui o controller altera o model

    }
    
    virtual public void NotifyDamageReceived() {
        m_model.IsEntityAlive = false; 
    }
}
