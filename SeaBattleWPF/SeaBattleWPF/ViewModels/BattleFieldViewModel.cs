using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace SeaBattleWPF.ViewModels
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
            for (var x = 0; x < _rows; x++)
            {
                for (var y = 0; y < _columns; y++)
                {
                    _cells[x, y] = new CellViewModel(x, y, Colors.Black);\
                }
            }

            OnPropertyChanged(nameof(AllCells));
        }

        #endregion


    }
}
