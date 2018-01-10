using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SeaBattleWPF.Pages;

namespace SeaBattleWPF
{
    public class BattleFieldCell : IBattleFieldCell
    {
        public UserControl Control => _control;

        GamePage _owner;
        UserControl _control;
        public BattleFieldCell(GamePage owner , int x, int y) 
        {
            _owner = owner;

            
            _control = new UserControl()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = owner.Colors[0], 
                BorderThickness = new Thickness(1.0),
                BorderBrush = Brushes.Transparent
            };
        }

        public int Value { get; set; }
        public int BorderValue { get; set; }
        public int X { get; }
        public int Y { get; }
    }
}
