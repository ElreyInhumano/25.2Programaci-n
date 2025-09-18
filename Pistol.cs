using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2Ejercicios
{
    class Pistol : Weapon
    {
        public Pistol(string weaponType, int dmg) : base(weaponType, dmg)
        {
        }
        public override string GetTypeW()
        {
            return this.weaponType;
        }
    }
}
