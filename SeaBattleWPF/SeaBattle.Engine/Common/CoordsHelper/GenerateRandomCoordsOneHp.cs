using System;
using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class GenerateRandomCoordsOneHp : BaseRandomCoords
    {
        public GenerateRandomCoordsOneHp(Map map) : base(map)
        {
            
        }

        public override List<Coords> GenerateCoords()
        {
            Random = new Random();

            var coords = new List<Coords>(); 

            while (coords.Count == 0)
            {
                var generatedCoords = new Coords(Random.Next(1, 10), Random.Next(1, 10));

                if (!Map.MapBlocks[generatedCoords.X, generatedCoords.Y].IsEmpty) continue;

                Map.MapBlocks[generatedCoords.X, generatedCoords.Y].IsEmpty = false;
                coords.Add(generatedCoords);
            }
           
            return coords;
        }
    }
}
