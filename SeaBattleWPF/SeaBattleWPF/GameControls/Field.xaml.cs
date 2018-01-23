using System;
using System.Windows;
using System.Windows.Controls;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattleWPF.GameControls
{
    public partial class Field
    {
        #region Public Fields

        public Map Map;
        public FieldCell[,] fieldCell;
        public int FieldSize { get; } = 10;

        #endregion

        #region Events 

        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseUp = delegate { };
        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseEnter = delegate { };
        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseLeave = delegate { };

        #endregion

        #region Constructor

        public Field()
        {
            InitializeComponent();

            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });

            fieldCell = new FieldCell[10, 10];
            Map = new Map();

            Map._ships = Map.GenerateDefaultShips(Map);
      
            Draw();
        }

        #endregion

        #region Private Methods

        private void Draw()
        {
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
                Grid.SetRow(hh, 0);
                Grid.SetColumn(hh, i + 1);

                var vh = new UserControl
                {
                    Content = (i + 1).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.Children.Add(vh);
                Grid.SetRow(vh, i + 1);
                Grid.SetColumn(vh, 0);

                for (var y = 0; y < FieldSize; y++)
                {
                    for (var x = 0; x < FieldSize; x++)
                    {
                        switch (Map.MapBlocks[x, y].State)
                        {
                            case BlockState.IsShip:
                                {
                                    var cell = new FieldCell(BlockState.IsShip, x, y);
                                    Grid.Children.Add(cell.Control);
                                    Grid.SetRow(cell.Control, y + 1);
                                    Grid.SetColumn(cell.Control, x + 1);

                                    fieldCell[x, y] = cell;

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
                                    Grid.SetRow(cell.Control, y + 1);
                                    Grid.SetColumn(cell.Control, x + 1);

                                    fieldCell[x, y] = cell;

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

        #endregion

        #region FieldColorsCollection Colors

        public ColorsCollection Colors
        {
            get => (ColorsCollection)GetValue(ColorsProperty);
            set => SetValue(ColorsProperty, value);
        }

        public static readonly DependencyProperty ColorsProperty =
            DependencyProperty.Register("Colors", typeof(ColorsCollection), typeof(Field), new UIPropertyMetadata(null));

        #endregion

        #region FieldColorsCollection BorderColors

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
