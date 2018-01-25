using System;
using System.Windows;
using System.Windows.Controls;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Ships;
using SeaBattleWPF.ViewModels;

namespace SeaBattleWPF.GameControls
{
    public partial class Field
    {
        #region Constructor

        public Field()
        {
            InitializeComponent();

            DataContext = new BattleFieldViewModel(10, 10);
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
