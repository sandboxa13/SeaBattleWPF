using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SeaBattleWPF.GameControls
{
    public class FieldCell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public UserControl Control { get; set; }

        public FieldCell(int x, int y)
        {
            X = x;
            Y = y;

            Control = new UserControl()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                BorderThickness = new Thickness(1.0),
                Background = Brushes.CornflowerBlue,
                BorderBrush = Brushes.Transparent
            };
        }
    }
}
