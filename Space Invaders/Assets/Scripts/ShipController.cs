using System;
using UnityEngine;

[Serializable]
public class ShipController : EntityController
{
    [SerializeField] private GameObject m_projectilePrefab;
  
    protected override void ProcessCommand(ShipCommand command)
    {
        if (command == ShipCommand.Shoot)
        {
            Shoot();
        }
        else
        {
            base.ProcessCommand(command);
        }
    }
    private void Shoot()
    {
        try 
        {
            GameObject projectileInstace = GameObject.Instantiate(m_projectilePrefab, m_model.Position, Quaternion.identity); //tenta criar um projetil na posicao da entidade
            projectileInstace.GetComponent<ProjectileView>().SetOwner(m_entityGameObject);//atribui owner no projetil
        }
        catch (Exception exception) //exemplo de exception é quando o prefab não existir
        {
            Debug.LogException(exception);
            Debug.LogError("Fault! Projectile prefab not set");
        }
    }
}
