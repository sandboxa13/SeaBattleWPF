using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using SeaBattleWPF.Core.ViewModels;

namespace SeaBattleWPF.ViewModels
{
    public class CellViewModel : BaseViewModel
    {
        public CellViewModel(int r, int c, Color color)
        {
            Row = r;
            Column = c;
            Background = color;

            Click = new RelayCommand(() => MessageBox.Show("" + Row + Column));
        }       

        public int Row { get; }
        public int Column { get; }
        public Color Background { get; }

        public ICommand Click { get; set; }
    }
}
