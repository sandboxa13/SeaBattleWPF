using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattleWPF.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage
    {

        public GamePage()
        {
            //Control = control;
            InitializeComponent();

            Colors = new BattleFieldColorsCollection(new[] { Brushes.SkyBlue });
            BorderColors = new BattleFieldColorsCollection(new[] { Brushes.Transparent });

            contents.Children.Clear();
            contents.RowDefinitions.Clear();
            contents.ColumnDefinitions.Clear();

            var sz = 10;

            var map = new Map();

            contents.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
            contents.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });

            for (var i = 0; i < sz; i++)
            {
                contents.RowDefinitions.Add(new RowDefinition());
                contents.ColumnDefinitions.Add(new ColumnDefinition());

                var hh = new UserControl()
                {
                    Content = ((char)('A' + i)).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                contents.Children.Add(hh);
                SetRow(hh, 0);
                SetColumn(hh, i + 1);

                var vh = new UserControl()
                {
                    Content = (i + 1).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                contents.Children.Add(vh);
                SetRow(vh, i + 1);
                SetColumn(vh, 0);
            }

            for (var y = 0; y < sz; y++)
            {
                for (var x = 0; x < sz; x++)
                {
                    var cell = new BattleFieldCell(this, x, y);
                    contents.Children.Add(cell.Control);
                    SetRow(cell.Control, y + 1);
                    SetColumn(cell.Control, x + 1);
                    cell.Control.PreviewMouseDown += (sender, ea) => ea.Handled = true;
                    cell.Control.MouseUp += (sender, ea) => OnBattleFieldCellMouseUp(this, new BattleFieldCellEventArgs(cell, ea));
                    cell.Control.MouseEnter += (sender, ea) => OnBattleFieldCellMouseEnter(this, new BattleFieldCellEventArgs(cell, ea));
                    cell.Control.MouseLeave += (sender, ea) => OnBattleFieldCellMouseLeave(this, new BattleFieldCellEventArgs(cell, ea));
                }
            }
        }

        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseUp = delegate { };
        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseEnter = delegate { };
        public event EventHandler<BattleFieldCellEventArgs> OnBattleFieldCellMouseLeave = delegate { };
        public BattleFieldColorsCollection Colors
        {
            get => (BattleFieldColorsCollection)GetValue(ColorsProperty);
            set => SetValue(ColorsProperty, value);
        }

        public static readonly DependencyProperty ColorsProperty =
            DependencyProperty.Register("Colors", typeof(BattleFieldColorsCollection), typeof(GamePage), new UIPropertyMetadata(null));

        
        public BattleFieldColorsCollection BorderColors
        {
            get => (BattleFieldColorsCollection)GetValue(BorderColorsProperty);
            set => SetValue(BorderColorsProperty, value);
        }

        public static readonly DependencyProperty BorderColorsProperty =
            DependencyProperty.Register("BorderColors", typeof(BattleFieldColorsCollection), typeof(GamePage), new UIPropertyMetadata(null));
    }
    public class BattleFieldColorsCollection : List<Brush>
    {
        public BattleFieldColorsCollection() { }
        public BattleFieldColorsCollection(IEnumerable<Brush> collection) : base(collection) { }
        public BattleFieldColorsCollection(int capacity) : base(capacity) { }
    }
}
