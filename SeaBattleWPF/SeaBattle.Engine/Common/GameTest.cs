using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Ships;

namespace SeaBattle.Engine.Common
{
    public class GameTest
    {
        private readonly List<BaseShip> _ships = new List<BaseShip>();

        private readonly Map _map = new Map();
        public GameTest()   
        {
            for (var i = 0; i < 2; i++)
            {
                _ships.Add(new TwoHpShip(_map));
            }

            for (var i = 0; i < 4; i++)
            {
                _ships.Add(new OneHpShip(_map));
                
            }
        }

        private bool CheckOnShoot(int x, int y)
        {
            return _map.MapBlocks[x, y].IsEmpty;
        }
    }
}
