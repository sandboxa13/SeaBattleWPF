using System;
using System.Collections.Generic;
using System.Linq;
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

            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] y = { 1, 2, 3, 4, 5, 6, 7, 8 };

            while (coords.Count != 2)
            {
                var generatedCoords = new Coords(Random.Next(0, 9), Random.Next(0, 9));
             

                if (!Map.MapBlocks[generatedCoords.X, generatedCoords.Y].IsEmpty) continue; // check this coord on map


                if (ExtremeValuesCoords.Contains(generatedCoords))
                {
                    coords = CheckExtremeValues(generatedCoords);
                }

                // check this coord on all sides
                else if (TopSideCoords.Contains(generatedCoords))
                {
                    coords = CheckTopSideValues(generatedCoords);
                }

                else if (BottomSideCoords.Contains(generatedCoords))
                {
                    coords = CheckBottomSideValues(generatedCoords);
                }

                else if (LeftSideCoords.Contains(generatedCoords))
                {
                    coords = CheckLeftSideValues(generatedCoords);
                }

                else if (RightSideCoords.Contains(generatedCoords))
                {
                    coords = CheckRightSideValues(generatedCoords);
                }

                // if all sides not contains this coord
                // generate new coord
          
                else if (x.Contains(generatedCoords.X) && y.Contains(generatedCoords.Y))
                {
                    coords = CheckDefaultSide(generatedCoords);
                }

                // set property IsEmpty to false
            }

            Map.MapBlocks[coords[0].X, coords[0].Y].IsEmpty = false;
            Map.MapBlocks[coords[1].X, coords[1].Y].IsEmpty = false;
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
                         coord2 = new Coords(coords.X + 10, coords.Y + 10);
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

            switch (rnd)
            {
                case 0:
                    if (Map.MapBlocks[coords.X - 1, coords.Y].IsEmpty)
                    {
                        list.Add(new Coords(coords.X - 1, coords.Y));
                    }
                    break;
                case 1:
                    if (Map.MapBlocks[coords.X, coords.Y - 1].IsEmpty)
                    {
                        list.Add(new Coords(coords.X, coords.Y - 1));
                    }
                    break;
                case 2:
                    if (Map.MapBlocks[coords.X + 1, coords.Y].IsEmpty)
                    {
                        list.Add(new Coords(coords.X + 1, coords.Y));
                    }
                    break;
                case 3:
                    if (Map.MapBlocks[coords.X, coords.Y + 1].IsEmpty)
                    {
                        list.Add(new Coords(coords.X, coords.Y + 1));
                    }
                    break;
            }

            return list;
        }
    }
}   
