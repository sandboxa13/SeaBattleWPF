using System.Collections.Generic;
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
            var ships = new List<BaseShip>
            {
                new OneHpShip(Map),
                new OneHpShip(Map),
                new OneHpShip(Map),
                new OneHpShip(Map),
                new TwoHpShip(Map),
                new TwoHpShip(Map),
                new TwoHpShip(Map),
                new ThreeHpShip(Map),
                new ThreeHpShip(Map)
            };

            return ships;
        }

        public void CheckOnShoot(Coords coord)
        {
            if (!Win)
            {
                if (Map.MapBlocks[coord.X, coord.Y].State != BlockState.IsBusy) return;

                Map.MapBlocks[coord.X, coord.Y].State = BlockState.IsShooted;

                foreach (var baseShip in Map._ships)
                {
                    foreach (var baseShipCoord in baseShip.Coords)
                    {
                        if (baseShipCoord.X != coord.X || baseShipCoord.Y != coord.Y) continue;

                        if (baseShip.Hp > 0)
                        {
                            baseShip.Hp--;
                        }
                        else
                        {
                            baseShip.IsAlive = false;
                        }
                    }
                }
            }
            else
            {
                // TODO Logic for handle playeer win
            }
        }
    }
}
