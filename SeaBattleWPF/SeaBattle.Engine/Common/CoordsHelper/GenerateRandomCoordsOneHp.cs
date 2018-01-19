using System;
using System.Collections.Generic;
using System.Threading;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class GenerateRandomCoordsOneHp : BaseRandomCoords
    {
        public GenerateRandomCoordsOneHp(Map map) : base(map)
        {
            Random = new Random((int)DateTime.Now.Ticks);

        }

        public override List<Coords> GenerateCoords()
        {
            var coords = new List<Coords>();



            while (coords.Count == 0)
            {
                Thread.Sleep(20);

                var generatedCoords = new Coords(Random.Next(1, 8), Random.Next(1, 8));

                if (Map.MapBlocks[generatedCoords.X, generatedCoords.Y].State == BlockState.IsBusy) continue;

                Map.MapBlocks[generatedCoords.X, generatedCoords.Y].State = BlockState.IsShip;

                coords.Add(generatedCoords);
            }

            return coords;
        }
    }
}
