using System;
using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class GenerateRandomCoordsOneHp : BaseRandomCoords
    {
        public GenerateRandomCoordsOneHp(Map map) : base(map)
        {
            Random = new Random();

            Coords = new List<Coords>();
        }

        public override List<Coords> GenerateCoords()
        {

            while (Coords.Count == 0)
            {
                var generatedCoord = new Coords(Random.Next(0, 9), Random.Next(0, 9)); // Genearte new coordinate

                if (CheckCoordinateOnMap(generatedCoord)) continue; // Check this coordinate on map

                SetBusyCells(generatedCoord); // Set the cells on the map as busy around the coordinate

                SetShipCells(generatedCoord); // Set coordinate on map to ship

                Coords.Add(generatedCoord);
            }   

            return Coords;
        }   
    }
}
