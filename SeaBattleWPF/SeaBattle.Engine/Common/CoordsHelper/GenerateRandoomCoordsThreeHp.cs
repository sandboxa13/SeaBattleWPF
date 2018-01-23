using System;
using System.Collections.Generic;
using System.Threading;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class GenerateRandoomCoordsThreeHp : BaseRandomCoords
    {
        public GenerateRandoomCoordsThreeHp(Map map) : base(map)
        {
        }

        public override List<Coords> GenerateCoords()
        {
            var coords = new List<Coords>();


            Thread.Sleep(20);

            Random = new Random();
            var number = Random.Next(0, 3);

            while (coords.Count != 3)
            {
                Thread.Sleep(20);

                var generatedcoords = new List<Coords>
                {
                    new Coords(Random.Next(2, 7), Random.Next(2, 7))
                };
                
                if(Map.MapBlocks[generatedcoords[0].X, generatedcoords[0].Y].State == BlockState.IsBusy || Map.MapBlocks[generatedcoords[0].X, generatedcoords[0].Y].State == BlockState.IsShip) continue;

                switch (number)
                {
                    case 0:
                        if (Map.MapBlocks[generatedcoords[0].X + 1, generatedcoords[0].Y].State == BlockState.IsEmpty)
                        {
                            if (Map.MapBlocks[generatedcoords[0].X + 2, generatedcoords[0].Y].State == BlockState.IsEmpty)
                            {
                                coords.Add(new Coords(generatedcoords[0].X, generatedcoords[0].Y));
                                coords.Add(new Coords(generatedcoords[0].X + 1, generatedcoords[0].Y));
                                coords.Add(new Coords(generatedcoords[0].X + 2, generatedcoords[0].Y));                                
                            }  
                        }
                        break;

                    case 1:
                        if (Map.MapBlocks[generatedcoords[0].X - 1, generatedcoords[0].Y].State == BlockState.IsEmpty)
                        {
                            if (Map.MapBlocks[generatedcoords[0].X - 2, generatedcoords[0].Y].State == BlockState.IsEmpty)
                            {
                                coords.Add(new Coords(generatedcoords[0].X, generatedcoords[0].Y));
                                coords.Add(new Coords(generatedcoords[0].X - 1, generatedcoords[0].Y));
                                coords.Add(new Coords(generatedcoords[0].X - 2, generatedcoords[0].Y));
                            }  
                        }
                        break;

                    case 2:
                        if (Map.MapBlocks[generatedcoords[0].X, generatedcoords[0].Y + 1].State == BlockState.IsEmpty)
                        {
                            if (Map.MapBlocks[generatedcoords[0].X, generatedcoords[0].Y + 2].State == BlockState.IsEmpty)
                            {
                                coords.Add(new Coords(generatedcoords[0].X, generatedcoords[0].Y));
                                coords.Add(new Coords(generatedcoords[0].X, generatedcoords[0].Y + 1));
                                coords.Add(new Coords(generatedcoords[0].X, generatedcoords[0].Y + 2));
                            }  
                        }
                        break;

                    case 3:
                        if (Map.MapBlocks[generatedcoords[0].X, generatedcoords[0].Y - 1].State == BlockState.IsEmpty)
                        {
                            if (Map.MapBlocks[generatedcoords[0].X, generatedcoords[0].Y - 2].State == BlockState.IsEmpty)
                            {
                                coords.Add(new Coords(generatedcoords[0].X, generatedcoords[0].Y));
                                coords.Add(new Coords(generatedcoords[0].X, generatedcoords[0].Y - 1));
                                coords.Add(new Coords(generatedcoords[0].X, generatedcoords[0].Y - 2));
                            }  
                        }
                        break;
                }
            }

            SetBusyCells(coords[0]);
            SetBusyCells(coords[1]);
            SetBusyCells(coords[2]);

            
            Map.MapBlocks[coords[0].X, coords[0].Y].State = BlockState.IsShip;
            Map.MapBlocks[coords[1].X, coords[1].Y].State = BlockState.IsShip;
            Map.MapBlocks[coords[2].X, coords[2].Y].State = BlockState.IsShip;

            return coords;
        }
    }
}
