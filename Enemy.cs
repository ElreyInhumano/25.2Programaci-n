using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2Ejercicios
{
    abstract class Enemy : IGetDamage
    {
        public string type;
        public string item;
        public Weapon weapon;
        public int life;

        protected Enemy(string type, string item, Weapon weapon, int life)
        {
            this.type = type;
            this.item = item;
            this.weapon = weapon;
            this.life = life;
        }

        public abstract void ReceiveDamage(int dmg);
    }
}
