using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        Weather weather;
        int weatherNum;
        string weatherString;
        int temp;

        public void RunDay()
        {
            weather = new Weather();
            weatherNum = weather.GetWeatherTypeNum();
            weatherString = weather.ConvertWeatherType(weatherNum);
            temp = weather.GetTemp();
        }
        public void DisplayWeather()
        {
            Console.WriteLine("Looks like it is " + weatherString + " outside. With a high of " + temp + ".");
        }
    }
}
