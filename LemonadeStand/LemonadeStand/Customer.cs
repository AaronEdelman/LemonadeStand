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
        //constructor
        public Customer(int temp)
        {
            this.temp = temp;
        }
        public void GetPropensityToBuy()
        {
            demand = new Random().Next(0, 100);
        }
        public void GetThirst()
        {
            float thirst = demand * temp;
        }
    }
}
