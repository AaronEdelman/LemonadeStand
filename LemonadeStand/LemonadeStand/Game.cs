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
        int dayCount = 1;
        int gameLength;
        public void RunGame()
        {
            SetGameLength();
            player = new Player();
            store = new Store();
            player.startBusiness();     
            while (dayCount < gameLength)
            {
                Console.WriteLine();
                day = new Day();
                day.RunDay();
                MainMenu();
                float recipeSum = player.SumRecipe();
                float recipeStrength = player.GetRecipeStrength(recipeSum);
                GetCustomerPreferences(recipeStrength);
                PlayerCustomerInterface();
                player.DisplayDayProfit();
                player.ResetSellcount();
                SpoilIce();
                dayCount++;
                ClearConsole();
            }
            player.DisplayTotalProfit();
            Console.ReadLine();
        }
        
        public void PlayerCustomerInterface()
        {
            foreach(Customer customer in day.customers)
            {
                if (customer.willBuy == true)
                {
                    player.SellLemonade();
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
        public void SpoilIce()
        {
            player.inventory.ice = 0;
            Console.WriteLine("All of your ice melted!");
        }
        public void ClearConsole()
        {
            Console.WriteLine("Press any key to continue.");
            string userInput = Console.ReadLine();
            Console.Clear();
        }
        public void MainMenu()
        {
            Console.WriteLine("Day "+ dayCount + "\n\nWhat would you like to do?\n\n[1] Check Inventory\n[2] Go to Store\n[3] Set Recipe\n[4] Set Price\n[5] Check Weather\n[6] Start Selling!!!! ");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5" && userInput != "6")
            {
                Console.Clear();
                MainMenu();
            }
                int userInputNum = int.Parse(userInput);
                switch (userInputNum)
                {
                    case 1:
                        Console.Clear();
                        InventoryMenu();
                        break;
                    case 2:
                        Console.Clear();
                        StoreMenu();
                        break;
                    case 3:
                        Console.Clear();
                        RecipeMenu();
                        break;
                    case 4:
                        Console.Clear();
                        player.SetPrice();
                        Console.Clear();
                        MainMenu();
                        break;
                case 5:
                        Console.Clear();
                        day.DisplayWeather();
                        Console.Clear();
                        MainMenu();
                        break;
                case 6:
                        break;
                }
        }
        public void InventoryMenu()
        {
            Console.WriteLine("Inventory\n\n");
            player.CheckInventory();
            Console.WriteLine("\n\n[1] Main Menu\n[2] Go to Store");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2")
            {
                Console.Clear();
                InventoryMenu();
            }
            int userInputNum = int.Parse(userInput);
            switch (userInputNum)
            {
                case 1:
                    Console.Clear();
                    MainMenu();
                    break;
                case 2:
                    Console.Clear();
                    StoreMenu();
                    break;
            }
        }
        public void StoreMenu()
        {
            Console.WriteLine("Welcome to the Lemon, Sugar, and Ice Shop.  We only sell Lemons, Sugar, and Ice. What would you like to buy?\n");
            player.CheckWallet();
            Console.WriteLine();
            store.DisplayAllPrices();
            Console.WriteLine("\n[1] Lemons\n[2] Sugar\n[3] Ice\n[4] All Ingrediants\n\n[5] Check Inventory\n[6] Main Menu");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5")
            {
                Console.Clear();
                StoreMenu();
            }
            int userInputNum = int.Parse(userInput);
            switch (userInputNum)
            {
                case 1:
                    Console.Clear();
                    int purchaseQuantity = player.GetPurchaseQuantity(store.lemons);
                    float subtotal = player.GetSubtotal(purchaseQuantity, store.lemonPrice);
                    player.CreditWallet(subtotal);
                    player.AddToInventory(store.lemons, purchaseQuantity);
                    player.CheckWallet();
                    Console.Clear();
                    StoreMenu();
                    break;
                case 2:
                    Console.Clear();
                    purchaseQuantity = player.GetPurchaseQuantity(store.sugar);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.sugarPrice);
                    player.CreditWallet(subtotal);
                    player.AddToInventory(store.sugar, purchaseQuantity);
                    player.CheckWallet();
                    Console.Clear();
                    StoreMenu();
                    break;
                case 3:
                    Console.Clear();
                    purchaseQuantity = player.GetPurchaseQuantity(store.ice);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.icePrice);
                    player.CreditWallet(subtotal);
                    player.AddToInventory(store.ice, purchaseQuantity);
                    player.CheckWallet();
                    Console.Clear();
                    StoreMenu();
                    break;
                case 4:
                    Console.Clear();
                    purchaseQuantity = player.GetPurchaseQuantity(store.lemons);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.lemonPrice);
                    player.CreditWallet(subtotal);
                    player.AddToInventory(store.lemons, purchaseQuantity);
                    player.CheckWallet();
                    purchaseQuantity = player.GetPurchaseQuantity(store.sugar);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.sugarPrice);
                    player.CreditWallet(subtotal);
                    player.AddToInventory(store.sugar, purchaseQuantity);
                    player.CheckWallet();
                    purchaseQuantity = player.GetPurchaseQuantity(store.ice);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.icePrice);
                    player.CreditWallet(subtotal);
                    player.AddToInventory(store.ice, purchaseQuantity);
                    Console.Clear();
                    StoreMenu();
                    break;
                case 5:
                    Console.Clear();
                    InventoryMenu();
                    break;
                case 6:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
        public void RecipeMenu()
        {
            Console.WriteLine("Lemonade Cookbook\n\n");
            player.AnnounceRecipe();
            Console.WriteLine("\n\n[1] Change # of Lemons\n[2] Change Amount of Sugar\n[3] Change Amount of Ice\n[4] Change All Ingrediants\n\n[5] Main Menu");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5")
            {
                Console.Clear();
                RecipeMenu();
            }
            int userInputNum = int.Parse(userInput);
            switch (userInputNum)
            {
                case 1:
                    Console.Clear();
                    player.ChangeRecipeLemons();
                    Console.Clear();
                    RecipeMenu();
                    break;
                case 2:
                    Console.Clear();
                    player.ChangeRecipeSugar();
                    Console.Clear();
                    RecipeMenu();
                    break;
                case 3:
                    Console.Clear();
                    player.ChangeRecipeIce();
                    Console.Clear();
                    RecipeMenu();
                    break;
                case 4:
                    Console.Clear();
                    player.ChangeRecipeAll();
                    Console.Clear();
                    RecipeMenu();
                    break;
                case 5:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
        public void SetGameLength()
        {
            Console.WriteLine("\nFor how many days would you like to sell lemonade?\n\n[1] 7 Days\n[2] 14 Days\n[3] 30 Days (not reccommended)");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3")
            {
                Console.Clear();
                SetGameLength();
            }
            int userInputNum = int.Parse(userInput);
            switch (userInputNum)
            {
                case 1:
                    Console.Clear();
                    gameLength = 8;
                    break;
                case 2:
                    Console.Clear();
                    gameLength = 15;
                    break;
                case 3:
                    Console.Clear();
                    gameLength = 31;
                    break;
            }
        }
    }
}
