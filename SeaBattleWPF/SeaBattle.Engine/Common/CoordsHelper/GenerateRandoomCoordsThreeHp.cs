using System;
using System.Collections.Generic;
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

            var rnd = new Random();

            var number = rnd.Next(0, 3);

            while (coords.Count != 3)
            {
                var generatedcoords = new GenerateRandomCoordsTwoHp(Map).GenerateCoords();

                switch (number)
                {
                    case 0:
                        if (CheckOnNullPlusX(generatedcoords) && CheckOnBusyPlusX(generatedcoords) )
                        {
                            generatedcoords.Add(new Coords(generatedcoords[1].X + 1, generatedcoords[1].Y));
                        }
                        break;

                    case 1:
                        if (CheckOnNullPlusY(generatedcoords) && CheckOnBusyPlusY(generatedcoords))
                        {
                            generatedcoords.Add(new Coords(generatedcoords[1].X, generatedcoords[1].Y + 1));
                        }
                        break;

                    case 2:
                        if ( CheckOnNullMinusX(generatedcoords) && CheckOnBusyMinusX(generatedcoords))
                        {
                            generatedcoords.Add(new Coords(generatedcoords[1].X - 1, generatedcoords[1].Y));
                        }
                        break;

                    case 3:
                        if (CheckOnNullMinusY(generatedcoords) && CheckOnBusyMinusY(generatedcoords))
                        {
                            generatedcoords.Add(new Coords(generatedcoords[1].X, generatedcoords[1].Y - 1));
                        }
                        break;
                }
                coords.AddRange(generatedcoords);
            }
            Map.MapBlocks[coords[2].X, coords[2].Y].State = BlockState.IsBusy;

            return coords;
        }

        #region PlusX
        private bool CheckOnNullPlusX(IReadOnlyList<Coords> generatedcoords)
        {
            return Map.MapBlocks[generatedcoords[1].X + 1, generatedcoords[1].Y] != null;
        }

        private bool CheckOnBusyPlusX(IReadOnlyList<Coords> generatedcoords)
        {
            return Map.MapBlocks[generatedcoords[1].X + 1, generatedcoords[1].Y].State == BlockState.IsEmpty;
        }
        #endregion

        #region PlusY

        private bool CheckOnNullPlusY(IReadOnlyList<Coords> generatedcoords)
        {
            return Map.MapBlocks[generatedcoords[1].X, generatedcoords[1].Y + 1] != null;
        }

        private bool CheckOnBusyPlusY(IReadOnlyList<Coords> generatedcoords)
        {
            return Map.MapBlocks[generatedcoords[1].X, generatedcoords[1].Y + 1].State == BlockState.IsEmpty;
        }

        #endregion

        #region MinusY

        private bool CheckOnNullMinusY(IReadOnlyList<Coords> generatedcoords)
        {
            return Map.MapBlocks[generatedcoords[1].X, generatedcoords[1].Y - 1] != null;
        }

        private bool CheckOnBusyMinusY(IReadOnlyList<Coords> generatedcoords)
        {
            return Map.MapBlocks[generatedcoords[1].X, generatedcoords[1].Y - 1].State == BlockState.IsEmpty;
        }

        #endregion

        #region MinusX
        private bool CheckOnNullMinusX(IReadOnlyList<Coords> generatedcoords)
        {
            return Map.MapBlocks[generatedcoords[1].X - 1, generatedcoords[1].Y] != null;
        }

        private bool CheckOnBusyMinusX(IReadOnlyList<Coords> generatedcoords)
        {
            return Map.MapBlocks[generatedcoords[1].X - 1, generatedcoords[1].Y].State == BlockState.IsEmpty;
        }
        #endregion
    }
}
