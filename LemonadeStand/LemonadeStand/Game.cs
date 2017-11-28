using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player;
        public Day day;
        Store store;
        int dayCount = 0;
        public void RunGame()
        {
            player = new Player();
            store = new Store();
            player.startBusiness();      
            day = new Day();
            day.RunDay();
            day.DisplayWeather();
            PlayerStoreInterface();
            player.AnnounceRecipe();
            player.ChangeRecipeOption();
            float recipeSum = player.SumRecipe();
            float recipeStrength = player.GetRecipeStrength(recipeSum);
            player.SetPrice();
            GetCustomerPreferences(recipeStrength);
            PlayerCustomerInterface();
            player.CheckWallet();
            player.CheckInventory();
            Console.ReadLine();
        }
        public void PlayerStoreInterface()
        {
            player.CheckInventory();
            player.CheckWallet();
            store.DisplayAllPrices();
            //lemons
            int purchaseQuantity = player.GetPurchaseQuantity(store.lemons);
            float subtotal = player.GetSubtotal(purchaseQuantity, store.lemonPrice);
            player.CreditWallet(subtotal);
            player.AddToInventory(store.lemons, purchaseQuantity);
            player.CheckWallet();
            //sugar
            purchaseQuantity = player.GetPurchaseQuantity(store.sugar);
            subtotal = player.GetSubtotal(purchaseQuantity, store.sugarPrice);
            player.CreditWallet(subtotal);
            player.AddToInventory(store.sugar, purchaseQuantity);
            player.CheckWallet();
            //ice
            purchaseQuantity = player.GetPurchaseQuantity(store.ice);
            subtotal = player.GetSubtotal(purchaseQuantity, store.icePrice);
            player.CreditWallet(subtotal);
            player.AddToInventory(store.ice, purchaseQuantity);
            player.CheckWallet();
        }
        public void PlayerCustomerInterface()
        {
            foreach(Customer customer in day.customers)
            {
                if (customer.willBuy == true)
                {
                    player.SellLemonade();
                    day.buyCount++;
                }
            }

        }
        public void GetCustomerPreferences(float recipeStrength)
        {
            foreach(Customer customer in day.customers)
            {
                customer.GetPropensityToBuy();
                customer.GetThirst();
                customer.GetBuyPower(recipeStrength, player.price);
                customer.BuyLemonadeDecision();
            }
        }
        public void CalculateDayProfit()
        {
            float profit = day.buyCount * player.price;
            Console.WriteLine("Profit = $" + profit);
        }
        public void SpoilIce()
        {
            player.inventory.ice = 0;
        }
    }
}
