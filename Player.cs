using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2Ejercicios
{
    class Player : IGetDamage, IGetHeal
    {
        string playerName;
        int life;
        int dmg;
        string item;
        private static Player instance;
        public Player(string playerName, int life, int dmg,string item)
        {
            this.playerName = playerName;
            this.life = life;
            this.dmg = dmg;
            this.item = item;
        }
        public void SetPlayerInstance()
        {
            instance = this;
        }
        public static Player GetPlayerInstance()
        {
            return instance;
        }
        public void ReceiveDamage(int dmg)
        {
            life -= dmg;
        }
        public int GetHeal(int heal)
        {
            return life + heal;
        }
        public int SetLife(int life)
        {
            return this.life = life;
        }
        public int SetDmg(int dmg)
        {
            return this.dmg = dmg;
        }
        public string SetName(string name)
        {
            return this.playerName = name;
        }
        public string SetItem(string item)
        {
            return this.item = item;
        }
        public int GetLife()
        {
            return life;
        }
        public int GetDmg()
        {
            return dmg;
        }
        public string GetName()
        {
            return playerName;
        }
        public string GetItem()
        {
            return item;
        }
    }
}
