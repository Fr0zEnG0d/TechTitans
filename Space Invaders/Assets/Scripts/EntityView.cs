using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EntityView : MonoBehaviour, IDamageReceiver
{
    
    [SerializeField] private EntityController m_controller = new EntityController(); //instancia EntityController
    protected List<ShipCommand> m_commands; //Define uma lista do tipo ShipCommand

    // Start is called before the first frame update
    void Start()
    {
        m_controller.InitializeEntityController(GetModel()); //estabelece uma dependencia (conexao direta) entre model e controller
        m_commands = new List<ShipCommand>(); //Cria a lista do tipo ShipCommand
    }

    // Update is called once per frame
    void Update()
    {
        BeforeUpdate(); 

        SendInputCommand(m_controller, m_commands); //Envia o input lido para o controller
        m_commands.Clear(); //limpa comandos

        UpdateTransform(GetModel()); //atualiza a posicao no componente Transform da Unity baseado no model

        if (!GetModel().IsEntityAlive) { Destroy(gameObject); } //quando a entidade morre ela é destruída na view

    }
    //Passa comandos para o controller
    public void SendInputCommand(EntityController entityController, List <ShipCommand> commands) 
    {
        entityController.ReceiveCommandsList(commands);
    }
    //atualiza a posicao a partir do Model
    void UpdateTransform(EntityModel entityModel) {
        transform.position = entityModel.Position;
    }

    virtual protected void BeforeUpdate() { }

    //Pega o model especifico das possiveis classes filhas e elas poderao fzer override
    virtual protected EntityModel GetModel() {
        return null;
    }

    virtual public void ReceiveDamage()
    {
        m_controller.NotifyDamageReceived();
    }
}
