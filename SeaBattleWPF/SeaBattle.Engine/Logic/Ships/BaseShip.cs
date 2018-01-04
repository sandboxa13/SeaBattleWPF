using System.Collections.Generic;
using SeaBattle.Engine.Common.Interfaces;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Logic.Ships
{
    public class BaseShip
    {
        public bool IsAlive { get; }
        public int Hp { get; }

        public List<Coords> Coords;
            
        protected IGenerateRandomCoords RandomCoords;

        public BaseShip(int hp) 
        {
            Hp = hp;
            IsAlive = true;
        }
    }
}
