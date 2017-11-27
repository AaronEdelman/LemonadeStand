using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        int weatherNum;
        string weatherString;
        public int temp;
        public List<Customer> customers = new List<Customer>();

        public void RunDay()
        {
            Weather weather = new Weather();
            weatherNum = weather.GetWeatherTypeNum();
            weatherString = weather.ConvertWeatherType(weatherNum);
            temp = weather.GetTemp();
            ChooseNumberOfCustomers(weatherString);
        }
        public void DisplayWeather()
        {
            Console.WriteLine("Looks like it is " + weatherString + " outside. With a high of " + temp + ".");
        }
        public void ChooseNumberOfCustomers(string weatherString)
        {
            switch(weatherString)
            {
                case "rainy":
                    GetCustomers(50);
                    break;
                case "cloudy":
                    GetCustomers(100);
                    break;
                case "sunny":
                    GetCustomers(200);
                    break;
            }
        }
        public void GetCustomers(int customerCount)
        {

            for(int i = 0; i < customerCount; i++)
            {
                Customer customer = new Customer(temp);
                customers.Add(customer);
            }
        }
    }
}
