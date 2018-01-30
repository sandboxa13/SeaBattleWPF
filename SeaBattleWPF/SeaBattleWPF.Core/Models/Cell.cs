using System.Windows.Input;
    
namespace SeaBattleWPF.Core.Models
{
    public class Cell
    {
        public Cell(int r, int c, string color)
        {
            Row = r;    
            Column = c;
            Background = color;           
        }

        private void SomeMethod()
        {
            
        }

        public int Row { get; }
        public int Column { get; }
        public string Background { get; }

        public ICommand Click { get; }
    }
}
