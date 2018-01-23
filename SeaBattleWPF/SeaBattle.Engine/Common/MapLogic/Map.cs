using System.Collections.Generic;
using SeaBattle.Engine.Ships;

namespace SeaBattle.Engine.Common.MapLogic
{   
    public class Map
    {
        public Block[,] MapBlocks;

        public List<BaseShip> _ships = new List<BaseShip>();

        public Map()
        {
            MapBlocks = new Block[10, 10];

            for (var j = 0; j < 10; j++)
            {
                for (var i = 0; i < 10; i++)
                {
                    MapBlocks[j, i] = new Block(j, i);
                }
            }
        }

        public List<BaseShip> GenerateDefaultShips(Map map)
        {
            var ships = new List<BaseShip>
            {
                new ThreeHpShip(map),
                new ThreeHpShip(map),

                new TwoHpShip(map),
                new TwoHpShip(map),
                new TwoHpShip(map),

                new OneHpShip(map),
                new OneHpShip(map),
                new OneHpShip(map),
                new OneHpShip(map),
            };

            return ships;
        }
    }
}
    