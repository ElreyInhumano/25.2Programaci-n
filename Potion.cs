using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2Ejercicios
{
    abstract class Potion : Item
    {
        protected Potion(string itemName, string itemType) : base(itemName, itemType)
        {
        }
    }
}
