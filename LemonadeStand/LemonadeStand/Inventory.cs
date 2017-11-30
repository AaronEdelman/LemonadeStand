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
        public float lemon;
        public float sugar;
        public float ice;

        public Inventory(float wallet)
        {
            this.wallet = wallet;
        }
        public bool VerifyPositiveWallet(float subtotal)
        {
            if (subtotal < wallet)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You do not have enough money");
                Console.ReadLine();
                return false;
            }
        }
    }
}
