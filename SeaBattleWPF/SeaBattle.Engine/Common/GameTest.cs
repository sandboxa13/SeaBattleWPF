using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Logic.Ships;

namespace SeaBattle.Engine.Common
{
    public class GameTest
    {
        public GameTest()
        {
            var map = new Map();

            var ships = new List<BaseShip>();

            for (var i = 0; i < 4; i++)
            {
                ships.Add(new TwoHpShip(map));
            }
        }
    }
}
