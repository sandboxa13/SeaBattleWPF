using System;
using System.Collections.Generic;

namespace SeaBattleWPF.Core.Logic.Ships.CoordsHelper
{
    public class GenerateRandomCoordsTwoHp : BaseRandomCoords
    {   
        public GenerateRandomCoordsTwoHp(Map map) : base(map)
        {
            
        }

        public override List<Coords> GenerateCoords()
        {
            _random = new Random();

            var coords = new Coords(_random.Next(1, 10), _random.Next(1, 10));

            var listCoords = new List<Coords>();

            if (!_map.MapBlocks[coords.X, coords.Y].IsEmpty) return listCoords;

            if (ExtremeValuesCoords.ContainsValue(coords))
            {
                listCoords = CheckExtremeValues(coords);
            }

            else if (TopSideCoords.ContainsValue(coords))
            {
                listCoords = CheckTopSideValues(coords);
            }

            else if (BottomSideCoords.ContainsValue(coords))
            {
                listCoords = CheckBottomSideValues(coords);
            }

            else if (LeftSideCoords.ContainsValue(coords))
            {
                listCoords = CheckLeftSideValues(coords);
            }

            else if (RightSideCoords.ContainsValue(coords))
            {
                listCoords = CheckRightSideValues(coords);
            }

            else
            {
                listCoords = CheckDefaultSide(coords);
            }

            return listCoords;
        }

        private List<Coords> CheckExtremeValues(Coords coords)
        {
            var rnd = _random.Next(0, 1);

            var list = new List<Coords> {coords};

            if (coords == ExtremeValuesCoords[0])
            {
                Coords coord2;

                switch (rnd)
                {
                    case 0:
                         coord2 = new Coords(coords.X + 1, coords.Y + 1);
                         list.Add(coord2);
                        break;
                    case 1:
                         coord2 = new Coords(coords.X + 1, coords.Y + 1);
                         list.Add(coord2);
                        break;
                }
            }

            if (coords == ExtremeValuesCoords[1])
            {
                Coords coord2;

                switch (rnd)
                {
                    case 0:
                        coord2 = new Coords(coords.X - 1, coords.Y - 1);
                        list.Add(coord2);
                        break;
                    case 1:
                        coord2 = new Coords(coords.X + 10, coords.Y + 10);
                        list.Add(coord2);
                        break;
                }
            }

            if (coords == ExtremeValuesCoords[2])
            {
                Coords coord2;

                switch (rnd)
                {
                    case 0:
                        coord2 = new Coords(coords.X + 1, coords.Y + 1);
                        list.Add(coord2);
                        break;
                    case 1:
                        coord2 = new Coords(coords.X - 10, coords.Y - 10);
                        list.Add(coord2);
                        break;
                }
            }

            if (coords == ExtremeValuesCoords[3])
            {
                Coords coord2;

                switch (rnd)
                {
                    case 0:
                        coord2 = new Coords(coords.X - 1, coords.Y - 1);
                        list.Add(coord2);
                        break;
                    case 1:
                        coord2 = new Coords(coords.X - 10, coords.Y - 10);
                        list.Add(coord2);
                        break;
                }
            }

            return list;
        }

        private List<Coords> CheckTopSideValues(Coords coords)
        {
            var rnd = _random.Next(0, 2);

            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (_map.MapBlocks[coords.X + 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X + 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (_map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (_map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y + 1);
                        list.Add(coord2);
                    }
                    break;
            }

            return list;
        }
            
        private List<Coords> CheckBottomSideValues(Coords coords)
        {
            var rnd = _random.Next(0, 2);

            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (_map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y + 1);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (_map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (_map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
            }

            return list;
        }

        private List<Coords> CheckLeftSideValues(Coords coords)
        {
            var rnd = _random.Next(0, 2);

            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (_map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y + 1);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (_map.MapBlocks[coords.X, coords.Y - 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y - 1);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (_map.MapBlocks[coords.X + 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X + 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
            }

            return list;
        }

        private List<Coords> CheckRightSideValues(Coords coords)
        {
            var rnd = _random.Next(0, 2);
                
            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (_map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y + 1);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (_map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (_map.MapBlocks[coords.X, coords.Y - 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y - 1);
                        list.Add(coord2);
                    }
                    break;
            }

            return list;
        }

        private List<Coords> CheckDefaultSide(Coords coords)
        {
            var rnd = _random.Next(0, 3);
                
            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (_map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (_map.MapBlocks[coords.X, coords.Y - 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y - 1);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (_map.MapBlocks[coords.X + 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X + 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 3:
                    if (_map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y + 1);
                        list.Add(coord2);
                    }
                    break;
            }

            return list;
        }
    }
}   
