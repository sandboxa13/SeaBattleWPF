using System.Windows;
using System.Windows.Controls;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Ships;

namespace SeaBattleWPF.GameControls
{
    /// <summary>
    /// Interaction logic for Field.xaml
    /// </summary>
    public partial class Field
    {
        private int FieldSize { get; } = 10;
        public Field()
        {
            InitializeComponent();

            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });

            for (var i = 0; i < 10; i++)
            {
                Grid.RowDefinitions.Add(new RowDefinition());
                Grid.ColumnDefinitions.Add(new ColumnDefinition());

                var hh = new UserControl
                {
                    Content = ((char)('A' + i)).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.Children.Add(hh);
                SetRow(hh, 0);
                SetColumn(hh, i + 1);

                var vh = new UserControl
                {
                    Content = (i + 1).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.Children.Add(vh);
                SetRow(vh, i + 1);
                SetColumn(vh, 0);

                var map = new Map();

                map._ships.Add(new ThreeHpShip(map));
                map._ships.Add(new ThreeHpShip(map));
               


                // map._ships.Add(new ThreeHpShip(map)); need fix this and test "index out of range exception"

                for (var y = 0; y < FieldSize; y++)
                {
                    for (var x = 0; x < FieldSize; x++)
                    {
                        if (map.MapBlocks[x, y].State == BlockState.IsBusy)
                        {
                            var cell = new FieldCell(BlockState.IsBusy, x, y);
                            Grid.Children.Add(cell.Control);
                            SetRow(cell.Control, y + 1);
                            SetColumn(cell.Control, x + 1);
                        }

                        else
                        {
                            var cell = new FieldCell(BlockState.IsEmpty, x, y);
                            Grid.Children.Add(cell.Control);
                            SetRow(cell.Control, y + 1);
                            SetColumn(cell.Control, x + 1);
                        }                                          
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
