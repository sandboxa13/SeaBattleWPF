using SeaBattle.Engine.Common.MapLogic;
using System;
using System.Collections.Generic;

namespace SeaBattle.Engine.Common.AI
{
    public sealed class Computer
    {
        #region Private Fields 

        private readonly List<Coords> _series;

        private readonly Random _random;

        private readonly Map _map;

        #endregion

        #region Public Methods

        public Coords GenerateCoord()
        {
            if (_series.Count == 0)
            {
                while (_series.Count == 0)
                {
                    var coord = new Coords(_random.Next(0, 9), _random.Next(0, 9));

                    _map.MapBlocks[coord.X, coord.Y].State = BlockState.IsShooted;

                    _series.Add(coord);

                    return coord;
                }
            }

            else
            {
                var coord = GenerateCoordHelper();

                return coord;
            }

            return null;
        }

        #endregion

        #region Private Methods

        private Coords GenerateCoordHelper()
        {
            switch (_series.Count)
            {
                case 1:
                    //need nested switch where generated new coord with random +x or +y or somthing else
                    return new Coords(_series[0].X + 1, _series[0].Y);

                case 2:

                    break;
            }

            return null;
        }

        #endregion

        #region Constructor 

        public Computer(Map map)
        {
            _map = new Map();
            _random = new Random();
            _series = new List<Coords>();
        }

        #endregion
    }
}
