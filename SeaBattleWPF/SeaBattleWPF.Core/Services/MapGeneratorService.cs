using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Ships;
using SeaBattleWPF.Core.Enums;
using SeaBattleWPF.Core.Models;

namespace SeaBattleWPF.Core.Services
{
    public class MapGeneratorService : IMapGeneratorService
    {
        private Map _map;   

        public Cell[,] GenerateMap(IServerHandlerService serverHandlerService)
        {
            _map = new Map();

            _map._ships.GenerateDefaultShips(_map);

            var _cells = new Cell[10, 10];

            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    switch (_map.MapBlocks[x, y].State)
                    {
                        case BlockState.IsShip:
                            _cells[x, y] = new Cell(x, y, "Red", serverHandlerService, CellStateEnum.IsShip);
                            break;
                        default:
                            _cells[x, y] = new Cell(x, y, "Black", serverHandlerService, CellStateEnum.IsEmpty);
                            break;
                    }
                }
            }

            return _cells;
        }

        public Cell[,] GenerateMap()
        {
            _map = new Map();

            _map._ships.GenerateDefaultShips(_map);

            var _cells = new Cell[10, 10];

            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    switch (_map.MapBlocks[x, y].State)
                    {
                        case BlockState.IsShip:
                            _cells[x, y] = new Cell(x, y, "Red", CellStateEnum.IsShip);
                            break;
                        default:
                            _cells[x, y] = new Cell(x, y, "Black", CellStateEnum.IsEmpty);
                            break;
                    }
                }
            }
            return _cells;
        }

        public IEnumerable<BaseShip> GenerateShips()
        {
            return null;
        }
    }
}
