using System.Windows.Input;

namespace SeaBattleWPF.Core.ViewModels
{
    public class CellViewModel : BaseViewModel
    {
        public CellViewModel(int r, int c, string color)
        {
            Row = r;
            Column = c;
            Background = color;

            
            Click = new RelayCommand(SomeMethod);
        }

        private void SomeMethod()
        {
            
        }

        public int Row { get; }
        public int Column { get; }
        public string Background { get; }

        public ICommand Click { get; set; }
    }
}
