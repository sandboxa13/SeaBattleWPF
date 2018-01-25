using System.Windows.Media;

namespace SeaBattleWPF.ViewModels
{
    public class CellViewModel : BaseViewModel
    {
        public CellViewModel(int r, int c, Color color)
        {
            Row = r;
            Column = c;
            Background = color;
        }       

        public int Row { get; }
        public int Column { get; }
        public Color Background { get; }
    }
}
