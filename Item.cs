using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2Ejercicios
{
    abstract class Item
    {
        protected string itemName;
        protected string itemType;
        protected Item(string itemName, string itemType)
        {
            this.itemName = itemName;
            this.itemType = itemType;
        }
    }
}
