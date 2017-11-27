using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        Inventory inventory;
        float initialMoney = 20;

        public void startBusiness ()
        {
            inventory = new Inventory(initialMoney);
        }
        public int GetPurchaseQuantity(string product)
        {
            Console.WriteLine("How many " + product + " would you like to buy?");
            string productQuantityString = Console.ReadLine();
            int productQuantityNum = Convert.ToInt32(productQuantityString);
            return productQuantityNum;
        }
        public float GetSubtotal(int prodQuantity, float prodPrice)
        {
            float cost;
            cost = prodQuantity * prodPrice;
            return cost;
        }
        public void CreditWallet(float prodCost)
        {
            inventory.wallet -= prodCost;
        }
        public void AddToInventory(string product, int prodQuantity)
        {
            switch (product)
            {
                case "lemons":
                    inventory.lemon += prodQuantity;
                    break;
                case "sugar":
                    inventory.sugar += prodQuantity;
                    break;
                case "ice":
                    inventory.ice += prodQuantity;
                    break;
            }
        }
        public void CheckWallet()
        {
            Console.WriteLine("You have $" + Math.Round(inventory.wallet, 2));
        }
        public void CheckInventory()
        {
               Console.WriteLine("You have " + inventory.lemon + " lemons left.");
               Console.WriteLine("You have " + inventory.sugar + " bags of sugar left.");
               Console.WriteLine("You have " + inventory.ice + " bags of ice left.");
        }
    }
}
