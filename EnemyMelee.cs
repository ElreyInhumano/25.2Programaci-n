using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2Ejercicios
{
    class EnemyMelee : Enemy
    {
        public EnemyMelee(string type, string item, Weapon weapon, int life): base(type, item, weapon, life)
        {

        }
        public override void ReceiveDamage(int dmg)
        {
            life -= dmg;
        }
    }
}
