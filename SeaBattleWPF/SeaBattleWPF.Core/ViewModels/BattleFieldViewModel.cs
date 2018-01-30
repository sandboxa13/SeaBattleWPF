using System.Collections.Generic;
using System.Linq;
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
            INavigationService navigationService)
        {   
            _cells = new Cell[10,10];

            _cells = mapGeneratorService.GenerateMap();

            AllCells = _cells.Cast<Cell>();
        }

        #endregion
    }
}
