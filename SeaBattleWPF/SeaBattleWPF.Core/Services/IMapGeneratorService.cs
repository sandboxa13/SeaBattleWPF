using System.Collections.Generic;
using SeaBattle.Engine.Ships;
using SeaBattleWPF.Core.Models;
using SeaBattleWPF.Core.ViewModels;

namespace SeaBattleWPF.Core.Services
{
    public interface IMapGeneratorService
    {   
        Cell[,] GenerateMap(IServerHandlerService serverHandlerService);

        Cell[,] GenerateMap();

        IEnumerable<BaseShip> GenerateShips();   
    }
}
