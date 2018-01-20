using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Ships;

namespace SeaBattleWPF.GameControls
{
    /// <summary>
    /// Interaction logic for Field.xaml
    /// </summary>
    /// 
    public class BattleFieldCellEventArgs : System.EventArgs
    {
        public FieldCell Cell { get; private set; }
        public MouseEventArgs MouseInfo { get; private set; }

        public MouseButton? Button { get; private set; }

        public BattleFieldCellEventArgs(FieldCell cell, MouseEventArgs mouseInfo)
        {
            Cell = cell;
            MouseInfo = mouseInfo;
            Button = (mouseInfo is MouseButtonEventArgs) ? (mouseInfo as MouseButtonEventArgs).ChangedButton : (MouseButton?)null;
        }
    }

    public partial class Field
    {
        private int FieldSize { get; } = 10;

        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseUp = delegate { };
        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseEnter = delegate { };
        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseLeave = delegate { };

        public Field()
        {
            InitializeComponent();

            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });

            OnBattleFieldCellMouseEnter += Field_OnBattleFieldCellMouseEnter;
            OnBattleFieldCellMouseLeave += Field_OnBattleFieldCellMouseLeave;
            OnBattleFieldCellMouseUp += Field_OnBattleFieldCellMouseUp;

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

                map._ships.Add(new TwoHpShip(map));
                map._ships.Add(new TwoHpShip(map));
                map._ships.Add(new TwoHpShip(map));

                map._ships.Add(new OneHpShip(map));
                map._ships.Add(new OneHpShip(map));
                map._ships.Add(new OneHpShip(map));
                map._ships.Add(new OneHpShip(map));

                for (var y = 0; y < FieldSize; y++)
                {
                    for (var x = 0; x < FieldSize; x++)
                    {
                        switch (map.MapBlocks[x, y].State)
                        {
                            case BlockState.IsShip:
                                {
                                    var cell = new FieldCell(BlockState.IsShip, x, y);
                                    Grid.Children.Add(cell.Control);
                                    SetRow(cell.Control, y + 1);
                                    SetColumn(cell.Control, x + 1);

                                    cell.Control.PreviewMouseDown += (sender, ea) => ea.Handled = true;
                                    cell.Control.MouseUp += (sender, ea) => OnBattleFieldCellMouseUp(this, new BattleFieldCellEventArgs(cell, ea));
                                    cell.Control.MouseEnter += (sender, ea) => OnBattleFieldCellMouseEnter(this, new BattleFieldCellEventArgs(cell, ea));
                                    cell.Control.MouseLeave += (sender, ea) => OnBattleFieldCellMouseLeave(this, new BattleFieldCellEventArgs(cell, ea));
                                    break;
                                }
                            default:
                                {
                                    var cell = new FieldCell(BlockState.IsEmpty, x, y);
                                    Grid.Children.Add(cell.Control);
                                    SetRow(cell.Control, y + 1);
                                    SetColumn(cell.Control, x + 1);

                                    cell.Control.PreviewMouseDown += (sender, ea) => ea.Handled = true;
                                    cell.Control.MouseUp += (sender, ea) => OnBattleFieldCellMouseUp(this, new BattleFieldCellEventArgs(cell, ea));
                                    cell.Control.MouseEnter += (sender, ea) => OnBattleFieldCellMouseEnter(this, new BattleFieldCellEventArgs(cell, ea));
                                    cell.Control.MouseLeave += (sender, ea) => OnBattleFieldCellMouseLeave(this, new BattleFieldCellEventArgs(cell, ea));
                                    break;
                                }
                        }
                    }
                }
            }
        }

        private void Field_OnBattleFieldCellMouseUp(object sender, BattleFieldCellEventArgs e)
        {
            MessageBox.Show("x - " + e.Cell.X + " y - " + e.Cell.Y);

            MessageBox.Show("state - " + e.Cell.State);
        }

        private void Field_OnBattleFieldCellMouseLeave(object sender, BattleFieldCellEventArgs e)
        {
        }

        private void Field_OnBattleFieldCellMouseEnter(object sender, BattleFieldCellEventArgs e)
        {
            
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
