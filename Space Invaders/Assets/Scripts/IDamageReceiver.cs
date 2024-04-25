using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Toda entidade que pode receber dano vai implementar essa interface
public interface IDamageReceiver
{
    void ReceiveDamage();
}

