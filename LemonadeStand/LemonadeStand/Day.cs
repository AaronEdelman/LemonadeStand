using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        string weatherString;
        public int temp;
        public List<Customer> customers = new List<Customer>();
        public int customerCount;
        Random r;

        //constructor
        public Day (Random r)
        {
            this.r = r;
        }
        public void RunDay()
        {
            Weather weather = new Weather(r);
            int weatherNum = weather.GetWeatherTypeNum();
            weatherString = weather.ConvertWeatherType(weatherNum);
            temp = weather.GetTemp();
            ChooseNumberOfCustomers(weatherString);
        }
        public void DisplayWeather()
        {
            Console.WriteLine("Looks like it is " + weatherString + " outside. With a high of " + temp + ".");
            Console.ReadLine();
        }
        private void ChooseNumberOfCustomers(string weatherString)
        {
            switch(weatherString)
            {
                case "rainy":
                    customerCount = 30;
                    GetCustomers(30);
                    break;
                case "cloudy":
                    customerCount = 60;
                    GetCustomers(60);
                    break;
                case "sunny":
                    customerCount = 120;
                    GetCustomers(120);
                    break;
            }
        }
        private void GetCustomers(int customerCount)
        {

            for(int i = 0; i < customerCount; i++)
            {
                Customer customer = new Customer(temp, r);
                customers.Add(customer);
            }
        }
    }
}
