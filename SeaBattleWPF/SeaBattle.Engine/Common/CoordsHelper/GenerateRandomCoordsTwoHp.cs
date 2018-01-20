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

            while (coords.Count != 2)
            {
                var generatedCoords = new Coords(Random.Next(1, 8), Random.Next(1, 8));

                if (Map.MapBlocks[generatedCoords.X, generatedCoords.Y].State == BlockState.IsShip) continue;

                var rnd = Random.Next(0, 3);

                switch (rnd)
                {
                    case 0:

                        if (Map.MapBlocks[generatedCoords.X + 1, generatedCoords.Y].State == BlockState.IsEmpty)
                        {
                            coords.Add(generatedCoords);
                            coords.Add(new Coords(generatedCoords.X + 1, generatedCoords.Y));                       
                        }
                        break;

                    case 1:

                        if (Map.MapBlocks[generatedCoords.X - 1, generatedCoords.Y].State == BlockState.IsEmpty)
                        {
                            coords.Add(generatedCoords);
                            coords.Add(new Coords(generatedCoords.X - 1, generatedCoords.Y));
                        }
                        break;

                    case 2:

                        if (Map.MapBlocks[generatedCoords.X, generatedCoords.Y - 1].State == BlockState.IsEmpty)
                        {
                            coords.Add(generatedCoords);
                            coords.Add(new Coords(generatedCoords.X, generatedCoords.Y - 1));
                        }
                        break;

                    case 3:

                        if (Map.MapBlocks[generatedCoords.X, generatedCoords.Y + 1].State == BlockState.IsEmpty)
                        {
                            coords.Add(generatedCoords);
                            coords.Add(new Coords(generatedCoords.X, generatedCoords.Y + 1));
                        }
                        break;
                }
            }

            Map.MapBlocks[coords[0].X, coords[0].Y].State = BlockState.IsShip;
            Map.MapBlocks[coords[1].X, coords[1].Y].State = BlockState.IsShip;

            return coords;
        }
    }
}
