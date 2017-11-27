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
            this.temp = temp/100;
        }
        public void GetPropensityToBuy()
        {
            demand = new Random().Next(0, 100)/100;
        }
        public void GetThirst()
        {
            thirst = demand + temp;
        }
        public void GetBuyPower(float recipe, float price)
        {
            buyPower = (thirst + recipe)*(1-price);
        }
        public void BuyLemonade()
        {
            if (buyPower > .5)
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
