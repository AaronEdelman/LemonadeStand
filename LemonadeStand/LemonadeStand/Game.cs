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
        Day day;
        Store store;
        int dayCount = 0;
        public void RunGame()
        {
            player = new Player();
            day = new Day();
            store = new Store();
            player.startBusiness();
            day.RunDay();
            day.DisplayWeather();
            store.DisplayAllPrices();
            Console.ReadLine();
        }
    }
}
