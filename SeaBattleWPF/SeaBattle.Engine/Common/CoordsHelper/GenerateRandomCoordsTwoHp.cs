using System;
using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class GenerateRandomCoordsTwoHp : BaseRandomCoords
    {   
        public GenerateRandomCoordsTwoHp(Map map) : base(map)
        {
            
        }

        public override List<Coords> GenerateCoords()
        {
            Random = new Random();

            var coords = new List<Coords>();

            while (coords.Count != 2)
            {
                var generatedCoords = new Coords(Random.Next(1, 10), Random.Next(1, 10));

                if (!Map.MapBlocks[generatedCoords.X, generatedCoords.Y].IsEmpty) continue;

                if (ExtremeValuesCoords.ContainsValue(generatedCoords))
                {
                    coords = CheckExtremeValues(generatedCoords);
                }

                else if (TopSideCoords.ContainsValue(generatedCoords))
                {
                    coords = CheckTopSideValues(generatedCoords);
                }

                else if (BottomSideCoords.ContainsValue(generatedCoords))
                {
                    coords = CheckBottomSideValues(generatedCoords);
                }

                else if (LeftSideCoords.ContainsValue(generatedCoords))
                {
                    coords = CheckLeftSideValues(generatedCoords);
                }

                else if (RightSideCoords.ContainsValue(generatedCoords))
                {
                    coords = CheckRightSideValues(generatedCoords);
                }

                else
                {
                    coords = CheckDefaultSide(generatedCoords);
                }

                Map.MapBlocks[coords[0].X, coords[0].Y].IsEmpty = false;
                Map.MapBlocks[coords[1].X, coords[1].Y].IsEmpty = false;
            }                                  
            return coords;
        }

        private List<Coords> CheckExtremeValues(Coords coords)
        {
            var rnd = Random.Next(0, 1);

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
            var rnd = Random.Next(0, 2);

            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (Map.MapBlocks[coords.X + 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X + 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (Map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (Map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
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
            var rnd = Random.Next(0, 2);

            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (Map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y + 1);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (Map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (Map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
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
            var rnd = Random.Next(0, 2);

            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (Map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y + 1);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (Map.MapBlocks[coords.X, coords.Y - 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y - 1);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (Map.MapBlocks[coords.X + 1, coords.Y].IsEmpty)
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
            var rnd = Random.Next(0, 2);
                
            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (Map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y + 1);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (Map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (Map.MapBlocks[coords.X, coords.Y - 1].IsEmpty)
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
            var rnd = Random.Next(0, 3);
                
            var list = new List<Coords> { coords };

            Coords coord2;

            switch (rnd)
            {
                case 0:
                    if (Map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X - 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 1:
                    if (Map.MapBlocks[coords.X, coords.Y - 1].IsEmpty)
                    {
                        coord2 = new Coords(coords.X, coords.Y - 1);
                        list.Add(coord2);
                    }
                    break;
                case 2:
                    if (Map.MapBlocks[coords.X + 1, coords.Y].IsEmpty)
                    {
                        coord2 = new Coords(coords.X + 1, coords.Y);
                        list.Add(coord2);
                    }
                    break;
                case 3:
                    if (Map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
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
