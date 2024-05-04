using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EntityController
{
    private EntityModel m_model;
    [SerializeField] private float m_speed;
    [SerializeField] private GameObject m_projectilePrefab;

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
        float maxposition = m_model.MaxPosition;
        switch (command)
        {
            case ShipCommand.MoveLeft:
                position.x += (-m_speed) * Time.deltaTime;
                break;
            case ShipCommand.MoveRight:
                position.x += m_speed * Time.deltaTime;
                break;
        }
        
        // Limitar a posição máxima lateral
        position.x = Mathf.Clamp(position.x, -maxposition, maxposition); // "maxposition" é a posição mínima e máxima permitida

        m_model.Position = position; // Aqui o controller altera o model

    }
    
    private void Shoot() {
        try
        {
            GameObject.Instantiate(m_projectilePrefab, m_model.Position, Quaternion.identity); //tenta criar um projetil na posicao da entidade
        }
        catch (Exception exception) //exemplo de exception é quando o prefab não existir
        {
            Debug.LogException(exception);
            Debug.LogError("Error! Projectile prefab not set");       
        }
    }

    virtual public void NotifyDamageReceived() {
        m_model.IsEntityAlive = false; 
    }
}
