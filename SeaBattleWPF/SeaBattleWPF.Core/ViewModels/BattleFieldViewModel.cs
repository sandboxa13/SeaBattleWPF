using System.Collections.Generic;
using System.Linq;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Ships;

namespace SeaBattleWPF.Core.ViewModels
{
    public class BattleFieldViewModel : BaseViewModel
    {
        #region Private Fileds

        private int _rows;
        private int _columns;
        private readonly CellViewModel[,] _cells;

        #endregion

        #region Public Properties

        public int Rows
        {
            get => _rows;

            set
            {
                _rows = value;

                OnPropertyChanged(nameof(Rows));
            }
        }

        public int Columns
        {
            get => _columns;

            set
            {
                _columns = value;

                OnPropertyChanged(nameof(Columns));
            }
        }

        public Map Map;

        public IEnumerable<CellViewModel> AllCells => _cells.Cast<CellViewModel>();

        #endregion

        #region Constructor 

        public BattleFieldViewModel(int r, int c)
        {
            _rows = r;
            _columns = c;

            _cells = new CellViewModel[_rows, _columns];

            GenerateCells();
        }

        #endregion

        #region Private Methods

        private void GenerateCells()
        {
            Map = new Map();

            Map._ships.GenerateDefaultShips(Map);

            for (var x = 0; x < _rows; x++)
            {
                for (var y = 0; y < _columns; y++)
                {
                    switch (Map.MapBlocks[x, y].State)
                    {
                        case BlockState.IsEmpty:
                            _cells[x, y] = new CellViewModel(x, y, "Black");
                            break;
                        case BlockState.IsShip:
                            _cells[x, y] = new CellViewModel(x, y, "Red");
                            break;
                        default:
                            _cells[x, y] = new CellViewModel(x, y, "Black");
                            break;
                    }
                }
            }
            OnPropertyChanged(nameof(AllCells));
        }

        #endregion
    }
}
