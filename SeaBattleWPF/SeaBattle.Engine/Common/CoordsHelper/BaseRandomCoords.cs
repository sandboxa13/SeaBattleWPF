using System;
using System.Collections.Generic;
using SeaBattle.Engine.Common.Interfaces;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.CoordsHelper
{
    public class BaseRandomCoords : IGenerateRandomCoords
    {
        #region Protected Fields 

        protected Map Map;

        protected Random Random;

        protected List<Coords> coords;

        #endregion

        #region Protected Methods

        protected void SetBusyCells(Coords coord)
        {
            if (coord.X + 1 < 10)
                Map.MapBlocks[coord.X + 1, coord.Y].State = BlockState.IsBusy;
            if (coord.X - 1 >= 0)
                Map.MapBlocks[coord.X - 1, coord.Y].State = BlockState.IsBusy;

            if (coord.Y + 1 < 10)
                Map.MapBlocks[coord.X, coord.Y + 1].State = BlockState.IsBusy;
            if (coord.Y - 1 >= 0)
                Map.MapBlocks[coord.X, coord.Y - 1].State = BlockState.IsBusy;

            if (coord.Y + 1 < 10 && coord.X + 1 < 10 && coord.X + 1 >= 0 && coord.Y + 1 >= 0)
                Map.MapBlocks[coord.X + 1, coord.Y + 1].State = BlockState.IsBusy;
            if (coord.Y - 1 >= 0 && coord.X - 1 >= 0 && coord.X - 1 < 10 && coord.Y - 1 < 10)
                Map.MapBlocks[coord.X - 1, coord.Y - 1].State = BlockState.IsBusy;

            if (coord.Y - 1 < 10 && coord.X + 1 < 10 && coord.X + 1 >= 0 && coord.Y - 1 >= 0)
                Map.MapBlocks[coord.X + 1, coord.Y - 1].State = BlockState.IsBusy;
            if (coord.Y + 1 >= 0 && coord.X - 1 >= 0 && coord.X - 1 < 10 && coord.Y + 1 < 10)
                Map.MapBlocks[coord.X - 1, coord.Y + 1].State = BlockState.IsBusy;

        }

        protected void SetBusyCells(IEnumerable<Coords> coords) {
            foreach (var coord in coords)           
                SetBusyCells(coord);
        }

        protected void SetShipCells(Coords coord) => Map.MapBlocks[coord.X, coord.Y].State = BlockState.IsShip;

        protected void SetShipCells(IEnumerable<Coords> coords)
        {
            foreach (var coord in coords)
                Map.MapBlocks[coord.X, coord.Y].State = BlockState.IsShip;
        }

        protected bool CheckCoordinateOnMap(Coords coord) => (Map.MapBlocks[coord.X, coord.Y].State == BlockState.IsBusy || Map.MapBlocks[coord.X, coord.Y].State == BlockState.IsShip) ? true : false;

        protected bool CheckOnIsEmpty(int x, int y) => Map.MapBlocks[x, y].State == BlockState.IsEmpty ? true : false;

        #endregion

        #region Constructor

        public BaseRandomCoords(Map map) => Map = map;

        #endregion

        public virtual List<Coords> GenerateCoords() => throw new NotImplementedException();
    }
}
