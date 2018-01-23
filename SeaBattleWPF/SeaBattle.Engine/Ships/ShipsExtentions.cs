using SeaBattle.Engine.Common.MapLogic;
using System.Collections.Generic;

namespace SeaBattle.Engine.Ships
{
    public static class ShipsExtentions
    {
        /// <summary>
        /// Getting ship state by his coordinate
        /// </summary>
        /// <param name="ships"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static bool GetShipStateOnCoord(this IEnumerable<BaseShip> ships, Coords coord)
        {
            foreach(var ship in ships)
            {
                switch (ship.Hp)
                {
                    case 1:
                        if (ship.Coords[0].X == coord.X && ship.Coords[0].Y == coord.Y)
                        {
                            return ship.IsAlive;
                        }

                        break;
                    case 2:
                        if (ship.Coords[0].X == coord.X && ship.Coords[0].Y == coord.Y ||
                            ship.Coords[1].X == coord.X && ship.Coords[1].Y == coord.Y)
                        {
                            return ship.IsAlive;
                        }

                        break;
                    case 3:
                        if (ship.Coords[0].X == coord.X && ship.Coords[0].Y == coord.Y ||
                            ship.Coords[1].X == coord.X && ship.Coords[1].Y == coord.Y ||
                            ship.Coords[2].X == coord.X && ship.Coords[2].Y == coord.Y)
                        {
                            return ship.IsAlive;

                        }

                        break;
                }
            }

            return false;
        }


        /// <summary>
        /// Generate a standard set of ships
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static IEnumerable<BaseShip> GenerateDefaultShips(this IEnumerable<BaseShip> enumerable, Map map)
        {
            enumerable = new List<BaseShip>
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

            return enumerable;
        }
    }
}
