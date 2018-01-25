using System.Collections.Generic;
using SeaBattle.Engine.Common.Interfaces;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Ships
{
    public class BaseShip
    {
        public bool IsAlive { get; set; }

        public int Hp { get; set; }

        public List<Coords> Coords;

        protected IGenerateRandomCoords RandomCoords;

        public BaseShip() => IsAlive = true;
    }
}
