using System;
using System.Collections.Generic;
using SeaBattle.Engine.Common.Interfaces;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class BaseRandomCoords : IGenerateRandomCoords
    {
        protected Map Map;

        protected Random Random;

        protected List<Coords> TopSideCoords = new List<Coords>
        {
            new Coords(2, 0),
            new Coords(3, 0), 
            new Coords(4, 0), 
            new Coords(5, 0),
            new Coords(6, 0),
            new Coords(7, 0), 
            new Coords(8, 0)
        };

        protected List<Coords> BottomSideCoords = new List<Coords>
        {
            new Coords(2, 9),
            new Coords(3, 9),
            new Coords(4, 9),
            new Coords(5, 9),
            new Coords(6, 9),
            new Coords(7, 9),
            new Coords(8, 9)
        };  

        protected List<Coords> LeftSideCoords = new List<Coords>
        {
            new Coords(0, 2),
            new Coords(0, 3),
            new Coords(0, 4), 
            new Coords(0, 5),
            new Coords(0, 6),
            new Coords(0, 7),
            new Coords(0, 8)
        };

        protected List<Coords> RightSideCoords = new List<Coords>
        {
            new Coords(9, 2),
            new Coords(9, 3),
            new Coords(9, 4),
            new Coords(9, 5),
            new Coords(9, 6),
            new Coords(9, 7),
            new Coords(9, 8)
        };

        protected List<Coords> ExtremeValuesCoords = new List<Coords>
        {
            new Coords(0, 0),
            new Coords(9, 9),
            new Coords(0, 9),
            new Coords(9, 0)
        };

        public BaseRandomCoords(Map map)
        {
            Map = map;
        }
        public virtual List<Coords> GenerateCoords()
        {
            throw new NotImplementedException();
        }
    }
}
