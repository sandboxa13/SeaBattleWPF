using System;
using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class GenerateRandoomCoordsThreeHp : BaseRandomCoords
    {
        public GenerateRandoomCoordsThreeHp(Map map) : base(map)
        {
            Random = new Random();

            coords = new List<Coords>();
        }

        public override List<Coords> GenerateCoords()
        {
            while (coords.Count != 3)
            {
                var generatedcoords = new List<Coords>
                {
                    new Coords(Random.Next(2, 7), Random.Next(2, 7))
                };

                if (CheckCoordinateOnMap(generatedcoords[0])) continue;

                var number = Random.Next(0, 3);

                switch (number)
                {
                    case 0:
                        if (CheckOnIsEmpty(generatedcoords[0].X + 1, generatedcoords[0].Y))
                        {
                            if (CheckOnIsEmpty(generatedcoords[0].X + 2, generatedcoords[0].Y))
                            {
                                coords = new List<Coords>
                                {
                                    new Coords(generatedcoords[0].X, generatedcoords[0].Y),
                                    new Coords(generatedcoords[0].X + 1, generatedcoords[0].Y),
                                    new Coords(generatedcoords[0].X + 2, generatedcoords[0].Y)
                                };
                            }
                        }
                        break;

                    case 1:
                        if (CheckOnIsEmpty(generatedcoords[0].X - 1, generatedcoords[0].Y))
                        {
                            if (CheckOnIsEmpty(generatedcoords[0].X - 2, generatedcoords[0].Y))
                            {
                                coords = new List<Coords>
                                {
                                    new Coords(generatedcoords[0].X, generatedcoords[0].Y),
                                    new Coords(generatedcoords[0].X - 1, generatedcoords[0].Y),
                                    new Coords(generatedcoords[0].X - 2, generatedcoords[0].Y)
                                };                          
                            }
                        }
                        break;

                    case 2:
                        if (CheckOnIsEmpty(generatedcoords[0].X, generatedcoords[0].Y + 1))
                        {
                            if (CheckOnIsEmpty(generatedcoords[0].X, generatedcoords[0].Y + 2))
                            {
                                coords = new List<Coords>
                                {
                                    new Coords(generatedcoords[0].X, generatedcoords[0].Y),
                                    new Coords(generatedcoords[0].X, generatedcoords[0].Y + 1),
                                    new Coords(generatedcoords[0].X, generatedcoords[0].Y + 2)
                                };
                            }
                        }
                        break;

                    case 3:
                        if (CheckOnIsEmpty(generatedcoords[0].X, generatedcoords[0].Y - 1))
                        {
                            if (CheckOnIsEmpty(generatedcoords[0].X, generatedcoords[0].Y - 2))
                            {
                                coords = new List<Coords>
                                {
                                    new Coords(generatedcoords[0].X, generatedcoords[0].Y),
                                    new Coords(generatedcoords[0].X, generatedcoords[0].Y - 1),
                                    new Coords(generatedcoords[0].X, generatedcoords[0].Y - 2)
                                };
                            }
                        }
                        break;
                }
            }

            SetBusyCells(coords);
            SetShipCells(coords);

            return coords;
        }
    }
}
