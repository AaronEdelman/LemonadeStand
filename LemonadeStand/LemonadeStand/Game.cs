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
        public float finalScore;
        public string name = "name";
        public Random r;
        public void RunGame()
        {
            WelcomePlayer();
            SetGameLength();
            player = new Player();
            store = new Store();
            player.startBusiness();
            while (dayCount < gameLength)
            {
                Console.WriteLine();
                GetRandomNumber();
                day = new Day(r);
                day.RunDay();
                MainMenu();
                Console.Clear();
                float recipeSum = player.SumRecipe();
                float recipeStrength = player.GetRecipeStrength(recipeSum);
                GetCustomerPreferences(recipeStrength);
                PlayerCustomerInterface();
                player.DisplaySaleStats(day.customerCount);
                player.DisplayDayProfit();
                player.ResetSellcount();
                SpoilIce();
                dayCount++;
                ClearConsole();
            }
            finalScore = player.inventory.wallet;
            player.DisplayTotalProfit();
            PlayAgainOption();
            Console.ReadLine();
        }
        
        private void PlayerCustomerInterface()
        {
            foreach(Customer customer in day.customers)
            {
                if (customer.willBuy == true)
                {
                    player.SellLemonade();
                }
            }

        }
        private void GetCustomerPreferences(float recipeStrength)
        {
            foreach(Customer customer in day.customers)
            {
                customer.GetPropensityToBuy();
                customer.GetThirst();
                customer.MaxPrice();
                customer.GetBuyPower(recipeStrength, player.price);
                customer.BuyLemonadeDecision();
            }
        }
        private void SpoilIce()
        {
            player.inventory.ice = 0;
            Console.WriteLine("All of your ice melted!");
        }
        private void ClearConsole()
        {
            Console.WriteLine("Press any key to continue.");
            string userInput = Console.ReadLine();
            Console.Clear();
        }
        private void MainMenu()
        {
            Console.WriteLine("Day "+ dayCount + "\n\nWhat would you like to do?\n\n[1] Check Inventory\n[2] Go to Store\n[3] Set Recipe\n[4] Set Price\n[5] Check Weather\n[6] Start Selling!!!! ");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5" && userInput != "6")
            {
                Console.Clear();
                MainMenu();
                return;
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
        private void InventoryMenu()
        {
            Console.WriteLine("Inventory\n\n");
            player.CheckInventory();
            Console.WriteLine("\n\n[1] Main Menu\n[2] Go to Store");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2")
            {
                Console.Clear();
                InventoryMenu();
                return;
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
        private void StoreMenu()
        {
            Console.WriteLine("Welcome to the Lemon, Sugar, and Ice Shop.  We only sell Lemons, Sugar, and Ice. What would you like to buy?\n");
            player.CheckWallet();
            Console.WriteLine();
            store.DisplayAllPrices();
            Console.WriteLine("\nBuy:\n[1] Lemons\n[2] Sugar\n[3] Ice\n[4] All Ingrediants\n\n[5] Check Inventory\n[6] Main Menu");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5" && userInput != "6")
            {
                Console.Clear();
                StoreMenu();
                return;
            }
            int userInputNum = int.Parse(userInput);
            switch (userInputNum)
            {
                case 1:
                    Console.Clear();
                    int purchaseQuantity = player.GetPurchaseQuantity(store.lemons);
                    float subtotal = player.GetSubtotal(purchaseQuantity, store.lemonPrice);
                    bool cashPositive = player.inventory.VerifyPositiveWallet(subtotal);
                    if (cashPositive == true)
                    {
                        player.CreditWallet(subtotal);
                        player.AddToInventory(store.lemons, purchaseQuantity);
                        player.CheckWallet();
                        Console.Clear();
                        StoreMenu();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        StoreMenu();
                    }
                    break;
                case 2:
                    Console.Clear();
                    purchaseQuantity = player.GetPurchaseQuantity(store.sugar);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.sugarPrice);
                    cashPositive = player.inventory.VerifyPositiveWallet(subtotal);
                    if (cashPositive == true)
                    {
                        player.CreditWallet(subtotal);
                        player.AddToInventory(store.sugar, purchaseQuantity);
                        player.CheckWallet();
                        Console.Clear();
                        StoreMenu();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        StoreMenu();
                    }
                    break;
                case 3:
                    Console.Clear();
                    purchaseQuantity = player.GetPurchaseQuantity(store.ice);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.icePrice);
                    cashPositive = player.inventory.VerifyPositiveWallet(subtotal);
                    if (cashPositive == true)
                    {
                        player.CreditWallet(subtotal);
                        player.AddToInventory(store.ice, purchaseQuantity);
                        player.CheckWallet();
                        Console.Clear();
                        StoreMenu();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        StoreMenu();
                    }
                    break;
                case 4:
                    Console.Clear();
                    purchaseQuantity = player.GetPurchaseQuantity(store.lemons);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.lemonPrice);
                    cashPositive = player.inventory.VerifyPositiveWallet(subtotal);
                    if (cashPositive == true)
                    {
                        player.CreditWallet(subtotal);
                        player.AddToInventory(store.lemons, purchaseQuantity);
                        player.CheckWallet();
                    }
                    purchaseQuantity = player.GetPurchaseQuantity(store.sugar);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.sugarPrice);
                    cashPositive = player.inventory.VerifyPositiveWallet(subtotal);
                    if (cashPositive == true)
                    {
                        player.CreditWallet(subtotal);
                        player.AddToInventory(store.sugar, purchaseQuantity);
                        player.CheckWallet();
                    }
                    purchaseQuantity = player.GetPurchaseQuantity(store.ice);
                    subtotal = player.GetSubtotal(purchaseQuantity, store.icePrice);
                    cashPositive = player.inventory.VerifyPositiveWallet(subtotal);
                    if (cashPositive == true)
                    {
                        player.CreditWallet(subtotal);
                        player.AddToInventory(store.ice, purchaseQuantity);
                    }
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
        private void RecipeMenu()
        {
            Console.WriteLine("Lemonade Cookbook\n\n");
            player.AnnounceRecipe();
            Console.WriteLine("\n\nPer Jug:\n[1] Change # of Lemons\n[2] Change Amount of Sugar\n[3] Change Amount of Ice\n[4] Change All Ingrediants\n\n[5] Main Menu");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5")
            {
                Console.Clear();
                RecipeMenu();
                return;
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
        private void SetGameLength()
        {
            Console.WriteLine("\nFor how many days would you like to sell lemonade?\n\n[1] 7 Days\n[2] 14 Days\n[3] 30 Days");
            string userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3")
            {
                Console.Clear();
                SetGameLength();
                return;
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
        public void GetRandomNumber()
        {
            r = new Random();
        }
        private void PlayAgainOption()
        {
            Console.WriteLine("Would you like to play again?");
            string userInput = Console.ReadLine();
            if (userInput == "yes" || userInput == "Yes" || userInput == "y" || userInput == "Y")
            {
                Console.Clear();
                RunGame();
            }
        }
        private void WelcomePlayer()
        {
            Console.WriteLine("Welcome to Aaron's Awesome Lemonade Stand.\n");
        }
    }
}
