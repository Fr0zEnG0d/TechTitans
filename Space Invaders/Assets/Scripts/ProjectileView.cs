using UnityEngine;

public class ProjectileView : EntityView {
    [SerializeField]
    private bool m_moveUp;  // se for projetil do player TRUE, se nao, FALSE
    [SerializeField]
    private ProjectileController m_projectileController = new ProjectileController();
    [SerializeField]
    private EntityModel m_model = new EntityModel();
    public void SetOwner(GameObject owner)
    {
        m_projectileController.SetOwner(owner); 
    }
    protected override void BeforeUpdate() //no caso do player o projetil move para cima e no caso do invader move para baixo
    {
        if (m_moveUp) 
        {
            m_commands.Add(ShipCommand.MoveUp);
        }
        else
        {
            m_commands.Add(ShipCommand.MoveDown);
        }
    }

    protected override EntityModel GetModel()
    {
        return m_model;
    }
    protected override EntityController GetController()
    {
        return m_projectileController;
    }
}
