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
        public int getPurchaseQuantity(string product)
        {
            Console.WriteLine("How many" + product + " would you like to buy?");
            string productQuantityString = Console.ReadLine();
            int productQuantityNum = Convert.ToInt32(productQuantityString);
            return productQuantityNum;
        }
        public int GetSubtotal(int prodQuantity, int prodPrice)
        {
            int cost;
            cost = prodQuantity * prodPrice;
            return cost;
        }
        public void creditWallet(int prodCost)
        {
            inventory.wallet -= prodCost;
        }
        public void addToIceInventory(int prodQuantity)
        {
            inventory.ice += prodQuantity;
        }
        public void addToLemonInventory(int prodQuantity)
        {
            inventory.lemon += prodQuantity;
        }
        public void addToSugarInventory(int prodQuantity)
        {
            inventory.sugar += prodQuantity;
        }
        public void BuyItem(int prodQuantity)
        {

        }

    }
}
