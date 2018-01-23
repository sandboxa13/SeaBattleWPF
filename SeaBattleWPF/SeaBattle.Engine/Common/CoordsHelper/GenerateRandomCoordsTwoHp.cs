﻿using System;
using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class GenerateRandomCoordsTwoHp : BaseRandomCoords
    {
        public GenerateRandomCoordsTwoHp(Map map) : base(map)
        {
            Random = new Random();

            coords = new List<Coords>();
        }

        public override List<Coords> GenerateCoords()
        {
            while (coords.Count != 2)
            {
                var generatedCoords = new Coords(Random.Next(1, 8), Random.Next(1, 8));

                if (CheckCoordinateOnMap(generatedCoords)) continue;

                var rnd = Random.Next(0, 3);

                switch (rnd)
                {
                    case 0:
                        if (CheckOnIsEmpty(generatedCoords.X + 1, generatedCoords.Y))
                            coords = new List<Coords>
                            {
                                generatedCoords,
                                new Coords(generatedCoords.X + 1, generatedCoords.Y),
                            };                     
                        break;

                    case 1:
                        if (CheckOnIsEmpty(generatedCoords.X - 1, generatedCoords.Y))
                            coords = new List<Coords>
                            {
                                generatedCoords,
                                new Coords(generatedCoords.X - 1, generatedCoords.Y),
                            };                       
                        break;

                    case 2:
                        if (CheckOnIsEmpty(generatedCoords.X, generatedCoords.Y - 1))                      
                            coords = new List<Coords>
                            {
                                generatedCoords,
                                new Coords(generatedCoords.X, generatedCoords.Y - 1),
                            };                  
                        break;

                    case 3:
                        if (CheckOnIsEmpty(generatedCoords.X, generatedCoords.Y + 1))
                            coords = new List<Coords>
                            {
                                generatedCoords,
                                new Coords(generatedCoords.X, generatedCoords.Y + 1),
                            };
                        break;
                }
            }

            SetBusyCells(coords);

            SetShipCells(coords);

            return coords;
        }
    }
}
