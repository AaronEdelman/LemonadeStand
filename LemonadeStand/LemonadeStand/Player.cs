using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public Inventory inventory;
        float initialMoney = 20;
        int[] recipe = new int[] { 2, 2, 2 };
        public float price = .25F;
        float cupsPerJug = 15;
        public int sellCount = 0;

        public void startBusiness()
        {
            inventory = new Inventory(initialMoney);
        }
        public int GetPurchaseQuantity(string product)
        {
            Console.WriteLine("How many " + product + " would you like to buy?");
            string productQuantityString = Console.ReadLine();
            int productQuantityNum = ValidatePurchaseQuantity(productQuantityString);
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
        public void DebitWallet()
        {
            inventory.wallet += price;
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
            Console.WriteLine("You have " + Math.Round(inventory.lemon, 1) + " lemons.");
            Console.WriteLine("You have " + Math.Round(inventory.sugar, 1) + " bags of sugar.");
            Console.WriteLine("You have " + Math.Round(inventory.ice, 1) + " bags of ice.");
        }
        public void AnnounceRecipe()
        {
            Console.WriteLine("A jug of lemonade has " + recipe[0] + " lemons, " + recipe[1] + " bags of sugar, and " + recipe[2] + " bags of ice.");
        }
        public void ChangeRecipeLemons()
        {
            Console.WriteLine("Change # of lemons in each jug to:");
            string lemonRecipe = Console.ReadLine();
            int recipeNum = ValidateRecipeQuantity(lemonRecipe);
            recipe[0] = recipeNum;
        }
        public void ChangeRecipeSugar()
        {
            Console.WriteLine("Change # of bags of sugar in each jug to:");
            string sugarRecipe = Console.ReadLine();
            int recipeNum = ValidateRecipeQuantity(sugarRecipe);
            recipe[1] = recipeNum;
        }
        public void ChangeRecipeIce()
        {
            Console.WriteLine("Change # of bags of ice in each jug to:");
            string iceRecipe = Console.ReadLine();
            int recipeNum = ValidateRecipeQuantity(iceRecipe);
            recipe[2] = recipeNum;
        }
        public void ChangeRecipeAll()
        {
            ChangeRecipeLemons();
            ChangeRecipeSugar();
            ChangeRecipeIce();
        }
        public float SumRecipe()
        {
            float recipeSum = 0;
            for (int i = 0; i < 3; i++)
            {
                recipeSum += recipe[i];
            }
            return recipeSum;
        }
        public float GetRecipeStrength(float recipeSum)
        {
            float recipeStrength = recipeSum / 6; //recipe elasticity coefficent
            return recipeStrength;
        }
        public void SetPrice()
        {
            Console.WriteLine("Current price per cup is $" + price + ". What should the price be set to?");
            string priceString = Console.ReadLine();
            ValidateSetPrice(priceString);
        }
        public void DecreaseInventory()
        {
            inventory.lemon -= (float)Math.Round(recipe[0] / cupsPerJug, 2);
            inventory.sugar -= (float)Math.Round(recipe[1] / cupsPerJug, 2);
            inventory.ice -= (float)recipe[2] / cupsPerJug;
        }
        public void SellLemonade()
        {
            if (inventory.lemon > 0 && inventory.sugar > 0 && inventory.ice > 0)
            {
                DebitWallet();
                DecreaseInventory();
                sellCount++;
            }
        }
        public void ResetSellcount()
        {
            sellCount = 0;
        }
        public void DisplayDayProfit()
        {
            float profit = sellCount * price;
            Console.WriteLine("Today's revenue = $" + profit);
        }
        public void DisplayTotalProfit()
        {
            Console.WriteLine();
            if (inventory.wallet >= 20)
            {
                Console.WriteLine("Congratulations! At the end of the week you made $" + ((float)Math.Round(inventory.wallet, 2) - 20));
            }
            else
            {
                Console.WriteLine("You lost " + (20 - (float)Math.Round(inventory.wallet, 2)) + ".  Bad Job!");
            }
        }
        public void DisplaySaleStats(int customerCount)
        {
            Console.WriteLine("You sold a total of " + sellCount + " lemonades to " + customerCount + " people that passed by.");
        }
        private void ValidateSetPrice(string priceString)
        {
            if (Single.TryParse(priceString, out price)) ;
            else
            {
                Console.WriteLine("Write a number. ex '.45'.");
                price = .25F;
            }
        }
        private int ValidateRecipeQuantity(string recipeInput)
        {
            int recipeNum;
            if (int.TryParse(recipeInput, out recipeNum)) ;
            else
            {
                Console.WriteLine("\nWrite a number. ex: '3'. Amount changed to '2'.");
                Console.ReadLine();
                recipeNum = 2;
            }
            return recipeNum;
        }
        private int ValidatePurchaseQuantity(string productQuantityString)
        {
            int quantityNum;
            if (int.TryParse(productQuantityString, out quantityNum)) ;
            return quantityNum;
        }
    }
}
