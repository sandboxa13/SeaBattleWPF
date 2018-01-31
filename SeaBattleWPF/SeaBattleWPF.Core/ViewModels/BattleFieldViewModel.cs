using System.Collections.Generic;
using System.Linq;
using SeaBattleWPF.Core.Enums;
using SeaBattleWPF.Core.Models;
using SeaBattleWPF.Core.Services;

namespace SeaBattleWPF.Core.ViewModels
{
    public class BattleFieldViewModel : BaseViewModel
    {
        #region Private Fileds

        private readonly Cell[,] _cells;

        #endregion

        #region Public Properties      

        public IEnumerable<Cell> AllCells
        {
            get => _cells.Cast<Cell>();

            set => OnPropertyChanged(nameof(AllCells));
        }


        #endregion

        #region Constructor 

        public BattleFieldViewModel(
            IMapGeneratorService mapGeneratorService,   
            INavigationService navigationService,
            IServerHandlerService serverHandlerService)
        {   
            _cells = new Cell[10,10];

            _cells = mapGeneratorService.GenerateMap(serverHandlerService);

            AllCells = _cells.Cast<Cell>();

            serverHandlerService.CheckCoordinate += ServerHandlerService_CheckCoordinate;
        }

        private void ServerHandlerService_CheckCoordinate(Message message)
        {
            var numbers = message.message.Split(' ').Select(int.Parse).ToList();

            if (_cells[numbers[0], numbers[1]].BlockState != CellStateEnum.IsShip) return;

            _cells[numbers[0], numbers[1]].Background = "White";

            OnPropertyChanged(nameof(AllCells));
        }

        #endregion
    }
}
