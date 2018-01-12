using System.Windows;
using System.Windows.Controls;

namespace SeaBattleWPF.GameControls
{
    /// <summary>
    /// Interaction logic for Field.xaml
    /// </summary>
    public partial class Field 
    {
        public Field()
        {
            InitializeComponent();

            Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });

            for (var i = 0; i < 10; i++)
            {
                Grid.RowDefinitions.Add(new RowDefinition());
                Grid.ColumnDefinitions.Add(new ColumnDefinition());

                var hh = new UserControl()
                {
                    Content = ((char)('A' + i)).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.Children.Add(hh);
                SetRow(hh, 0);
                SetColumn(hh, i + 1);

                var vh = new UserControl()
                {
                    Content = (i + 1).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.Children.Add(vh);
                SetRow(vh, i + 1);
                SetColumn(vh, 0);

                for (var y = 0; y < 10; y++)
                {
                    for (var x = 0; x < 10; x++)
                    {
                        var cell = new FieldCell(x, y);
                        Grid.Children.Add(cell.Control);
                        SetRow(cell.Control, y + 1);
                        SetColumn(cell.Control, x + 1);                        
                    }
                }
            }
        }

        #region BattleFieldColorsCollection Colors

        public ColorsCollection Colors
        {
            get => (ColorsCollection)GetValue(ColorsProperty);
            set => SetValue(ColorsProperty, value);
        }

        public static readonly DependencyProperty ColorsProperty =
            DependencyProperty.Register("Colors", typeof(ColorsCollection), typeof(Field), new UIPropertyMetadata(null));

        #endregion

        #region BattleFieldColorsCollection BorderColors

        public ColorsCollection BorderColors
        {
            get => (ColorsCollection)GetValue(BorderColorsProperty);
            set => SetValue(BorderColorsProperty, value);
        }

        public static readonly DependencyProperty BorderColorsProperty =
            DependencyProperty.Register("BorderColors", typeof(ColorsCollection), typeof(Field), new UIPropertyMetadata(null));

        #endregion
    }
}
