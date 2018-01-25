using SeaBattle.Engine.Common.MapLogic;
using System;
using System.Collections.Generic;
using SeaBattle.Engine.Ships;

namespace SeaBattle.Engine.Common.AI
{
    public sealed class Computer
    {
        #region Private Fields 

        private List<Coords> _series;

        private readonly Random _random;

        private readonly Map _map;

        private readonly Map _playerMap;

        #endregion

        #region Public Methods

        public Coords GenerateCoord()
        {
            if (_series.Count == 0)
            {
                while (_series.Count == 0)
                {                   
                    var coord = new Coords(_random.Next(0, 9), _random.Next(0, 9));

                    if(_map.MapBlocks[coord.X, coord.Y].State == BlockState.IsShooted || !_playerMap._ships.GetShipStateOnCoord(coord)) continue;

                    _map.MapBlocks[coord.X, coord.Y].State = BlockState.IsShooted;

                    _series.Add(coord);

                    return coord;
                }
            }

            else
            {
                if (!_map._ships.GetShipStateOnCoord(_series[0]))
                {
                    _series = new List<Coords>();

                    while (_series.Count == 0)
                    {
                        var nextcoord = new Coords(_random.Next(0, 9), _random.Next(0, 9));

                        if (_map.MapBlocks[nextcoord.X, nextcoord.Y].State == BlockState.IsShooted) continue;

                        _map.MapBlocks[nextcoord.X, nextcoord.Y].State = BlockState.IsShooted;

                        _series.Add(nextcoord);

                        return nextcoord;
                    }
                }

                var coord = GenerateCoordHelper();

                _series.Add(coord);

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
                    return SingleRandomCoordHelper();
                case 2:

                    break;
            }

            return null;
        }

        private Coords SingleRandomCoordHelper()
        {
            var rnd = new Random().Next(0, 3);

            switch (rnd)
            {
                case 0:
                    return new Coords(_series[0].X + 1, _series[0].Y);
                case 1:
                    return new Coords(_series[0].X - 1, _series[0].Y);
                case 2:
                    return new Coords(_series[0].X, _series[0].Y + 1);
                case 3:
                    return new Coords(_series[0].X, _series[0].Y - 1);
            }

            return null;
        }

        #endregion

        #region Constructor 

        public Computer(Map map)
        {
            _map = new Map();
            _playerMap = map;
            _random = new Random();
            _series = new List<Coords>();
        }

        #endregion
    }
}
