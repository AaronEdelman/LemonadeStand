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
        int[] recipe = new int[] { 2, 2, 2 };
        float price = .25F;

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
        public void DebitWallet(float sale)
        {
            inventory.wallet += sale;
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
        public void AnnounceRecipe()
        {
            Console.WriteLine("A jug of lemonade has " + recipe[0] + " lemons, " + recipe[1] + " bags of sugar. and " + recipe [2] + " bags of ice.");
        }
        public void ChangeRecipeLemons()
        {
            Console.WriteLine("Change # of lemons in each jug to:");
            string lemonRecipe = Console.ReadLine();
            int lemonRecipeNum = int.Parse(lemonRecipe);
            recipe[0] = lemonRecipeNum;
        }
        public void ChangeRecipeSugar()
        {
            Console.WriteLine("Change # of bags of sugar in each jug to:");
            string sugarRecipe = Console.ReadLine();
            int sugarRecipeNum = int.Parse(sugarRecipe);
            recipe[1] = sugarRecipeNum;
        }
        public void ChangeRecipeIce()
        {
            Console.WriteLine("Change # of bags of ice in each jug to:");
            string iceRecipe = Console.ReadLine();
            int iceRecipeNum = int.Parse(iceRecipe);
            recipe[2] = iceRecipeNum;
        }
        public void ChangeRecipeAll()
        {
            ChangeRecipeLemons();
            ChangeRecipeSugar();
            ChangeRecipeIce();
        }
        public void ChangeRecipeOption()
        {
            Console.WriteLine("Would you like to change this recipe?");
            string userInput = Console.ReadLine();
            if (userInput == "yes" || userInput == "Yes" || userInput == "y" || userInput == "Y")
            {
                ChangeRecipeAll();
            }
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
            float recipeStrength = recipeSum / 12;
            return recipeStrength;
        }
        public void SetPrice()
        {
            Console.WriteLine("Current price per cup is $" + price + ". What should the price be set to?");
            string priceString = Console.ReadLine();
            price = int.Parse(priceString);
        }
        public void SellLemonade()
        {

        }
    }
}
