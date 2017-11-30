using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        Random r;
        //constructor
        public Weather(Random r)
        {
            this.r = r;
        }
        public int GetWeatherTypeNum()
        {
            int weatherType = r.Next(0, 3);
            return weatherType;
        }
        public string ConvertWeatherType(int weatherNum)
        {
            string weatherType = "";
            switch (weatherNum)
            {
                case 0:
                    weatherType = "rainy";
                    break;
                case 1:
                    weatherType = "cloudy";
                    break;
                case 2:
                    weatherType = "sunny";
                    break;
            }
            return weatherType;
        }
        public int GetTemp()
        {
            int temp;
            temp = r.Next(40, 101);
            return temp;
        }
    }
}
