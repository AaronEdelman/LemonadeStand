using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public float wallet;
        public int lemon;
        public int sugar;
        public int ice;

        public Inventory(float wallet)
        {
            this.wallet = wallet;
        }
    }

}
