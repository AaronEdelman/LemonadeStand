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
            day = new Day();
            store = new Store();
            player.startBusiness();
            day.RunDay();
            day.DisplayWeather();
            PlayerStoreInterface();
            player.AnnounceRecipe();
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
    }
}
