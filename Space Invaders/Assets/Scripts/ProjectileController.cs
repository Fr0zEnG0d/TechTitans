using System;
using UnityEngine;

[Serializable]
public class ProjectileController : EntityController
{
    private GameObject m_owner;
    public void SetOwner(GameObject owner)
    {
        m_owner = owner;
    }
    protected override void ProcessCommand(ShipCommand command)
    {
        base.ProcessCommand(command); //reage aos comandos
        //deteccao de colisao
        Collider2D hit = Physics2D.OverlapBox(m_model.Position, new Vector2(0.15f, 0.5f),0);
        if(hit != null && hit.gameObject != m_owner)
        {
            IDamageReceiver damageReceiver = hit.gameObject.GetComponent<IDamageReceiver>();
            if(damageReceiver != null)
            {
                damageReceiver.ReceiveDamage();
                m_model.IsEntityAlive = false;
            }
        }
    }
}