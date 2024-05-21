using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//herda de ShipController pois faz tudo que ShipControler faz, EXCETO receiveDamage
[Serializable]
public class PlayerController : ShipController
{
    PlayerModel playerModel;
    public override void InitializeEntityController(EntityModel model)
    {
        base.InitializeEntityController(model);
        playerModel = (PlayerModel)model;
    }

    public override void NotifyDamageReceived()
    {
        playerModel.Lives--;
        if (playerModel.Lives <= 0)
        {
            playerModel.IsEntityAlive = false;
        }
    }
}

