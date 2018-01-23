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
            Random = new Random();
        }

        public override List<Coords> GenerateCoords()
        {
            var coords = new List<Coords>();

            while (coords.Count == 0)
            {
                Thread.Sleep(20);

                var generatedCoord = new Coords(Random.Next(0, 9), Random.Next(0, 9));

                if (Map.MapBlocks[generatedCoord.X, generatedCoord.Y].State == BlockState.IsBusy || Map.MapBlocks[generatedCoord.X, generatedCoord.Y].State == BlockState.IsShip) continue;

                SetBusyCells(generatedCoord);

                Map.MapBlocks[generatedCoord.X, generatedCoord.Y].State = BlockState.IsShip;

                coords.Add(generatedCoord);
            }   

            return coords;
        }

        
    }
}
