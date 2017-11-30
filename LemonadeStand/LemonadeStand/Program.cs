using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new LemonadeStand.Game();
            game.RunGame();

            //SqlConnect database = new SqlConnect();
            //database.ExecuteSqlTransaction(game.name);
        }
    }
}
