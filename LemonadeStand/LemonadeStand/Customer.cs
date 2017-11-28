using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        int temp;
        float demand;
        float thirst;
        float buyPower;
        public bool willBuy;
        //constructor
        public Customer(int temp)
        {
            this.temp = temp;
        }
        public void GetPropensityToBuy()
        {
            float demandRandom = new Random().Next(0, 101);
            demand = (float)demandRandom / 100;
        }
        public void GetThirst()
        {
            float tempFloat = (float)temp / 100;
            thirst = demand + tempFloat;
        }
        public void GetBuyPower(float recipeStrength, float price)
        {
            buyPower = (thirst * recipeStrength)*(1.25F-price); // price elasticity
        }
        public void BuyLemonadeDecision()
        {
            if (buyPower > 1)
            {
                willBuy = true;
            }
            else
            {
                willBuy = false;
            }
        }
    }
}
