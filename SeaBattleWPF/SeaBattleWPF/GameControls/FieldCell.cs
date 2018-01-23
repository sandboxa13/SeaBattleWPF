using System.Windows;
using System.Windows.Media;
using SeaBattle.Engine.Common.MapLogic;
using UserControl = System.Windows.Controls.UserControl;

namespace SeaBattleWPF.GameControls
{
    public class FieldCell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public BlockState State;

        public UserControl Control { get; set; }

        public FieldCell(BlockState state, int x, int y)
        {
            X = x;
            Y = y;
            State = state;

            switch (State)
            {
                case BlockState.IsShip:
                    Control = new UserControl
                    {
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        BorderThickness = new Thickness(1.0),
                        Background = Brushes.Red,
                        BorderBrush = Brushes.Transparent
                    };
                    break;


                default:
                    Control = new UserControl
                    {
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        BorderThickness = new Thickness(1.0),
                        Background = Brushes.CornflowerBlue,
                        BorderBrush = Brushes.Transparent
                    };
                    break;
            }          
        }
    }
}
