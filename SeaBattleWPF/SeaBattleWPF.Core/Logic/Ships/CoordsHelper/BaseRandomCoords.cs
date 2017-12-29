using System;
using System.Collections.Generic;
using SeaBattleWPF.Core.Logic.Interfaces;

namespace SeaBattleWPF.Core.Logic.Ships.CoordsHelper
{
    public class BaseRandomCoords : IGenerateRandomCoords
    {
        protected Map _map;

        protected Random _random;

        protected Dictionary<int, Coords> TopSideCoords = new Dictionary<int, Coords>
        {
            {1, new Coords(2, 1) },
            {2, new Coords(3, 1) }, 
            {3, new Coords(4, 1) },
            {4, new Coords(5, 1) },
            {5, new Coords(6, 1) },
            {6, new Coords(7, 1) }, 
            {7, new Coords(8, 1) },
            {8, new Coords(9, 1) },
        };

        protected Dictionary<int, Coords> BottomSideCoords = new Dictionary<int, Coords>
        {
            {1, new Coords(10, 2)},
            {2, new Coords(10, 3)},
            {3, new Coords(10, 4)},
            {4, new Coords(10, 5)},
            {5, new Coords(10, 6)},
            {6, new Coords(10, 7)},
            {7, new Coords(10, 8)},
            {8, new Coords(10, 9)}
        };  

        protected Dictionary<int, Coords> LeftSideCoords = new Dictionary<int, Coords>
        {
            {1, new Coords(1, 2) },
            {2, new Coords(1, 3) },
            {3, new Coords(1, 4) }, 
            {4, new Coords(1, 5) },
            {5, new Coords(1, 6) },
            {6, new Coords(1, 7) },
            {7, new Coords(1, 8) },
            {8, new Coords(1, 9) },
        };

        protected Dictionary<int, Coords> RightSideCoords = new Dictionary<int, Coords>
        {
            {1, new Coords(10, 2)},
            {2, new Coords(10, 3)},
            {3, new Coords(10, 4)},
            {4, new Coords(10, 5)},
            {5, new Coords(10, 6)},
            {6, new Coords(10, 7)},
            {7, new Coords(10, 8)},
            {8, new Coords(10, 9)}
        };

        protected Dictionary<int, Coords> ExtremeValuesCoords = new Dictionary<int, Coords>
        {
            {1, new Coords(1, 1) },
            {2, new Coords(10, 10) },
            {3, new Coords(1, 10) },
            {4, new Coords(10, 1) }
        };

        public BaseRandomCoords(Map map)
        {
            _map = map;
        }
        public virtual List<Coords> GenerateCoords()
        {
            throw new System.NotImplementedException();
        }
    }
}
