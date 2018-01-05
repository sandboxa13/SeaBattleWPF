using System.Collections.Generic;
using System.Linq;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Ships;

namespace SeaBattle.Engine.Common.Players
{
    public class Player
    {
        #region Public Properties

        public readonly Map Map;    
            
        public readonly Map EnemyMap;

        public bool Win { get; set; }

        public string Name { get; set; }

        #endregion 

        public Player()
        {
            Map = new Map();

            Win = false;

            EnemyMap = new Map();

            Map._ships.AddRange(GenerateDefaultShips());           
        }

        public Player(List<BaseShip> ships) => Map = new Map { _ships = ships };

        private IEnumerable<BaseShip> GenerateDefaultShips()
        {
            var ships = new List<BaseShip>();

            ships.AddRange(GeneratorHelper(new OneHpShip(Map), 4));
            ships.AddRange(GeneratorHelper(new TwoHpShip(Map), 4));

            return ships;
        }

        private static IEnumerable<BaseShip> GeneratorHelper(BaseShip ship, int count)
        {
            var ships = new List<BaseShip>();

            for (var i = 0; i < count; i++)
            {
                ships.Add(ship);
            }

            return ships;
        }

        private void CheckOnShoot(Coords coord)
        {
            if (!Win)
            {
                if (Map.MapBlocks[coord.X, coord.Y].State == BlockState.IsEmpty)
                {

                }
            }
        }
    }
}
