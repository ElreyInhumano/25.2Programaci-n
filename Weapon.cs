using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2Ejercicios
{
    abstract class Weapon
    {
        public string weaponType;
        public int dmg;
        protected Weapon(string weaponType, int dmg)
        {
            this.weaponType = weaponType;
            this.dmg = dmg;
        }
        public abstract string GetTypeW();
    }
}
