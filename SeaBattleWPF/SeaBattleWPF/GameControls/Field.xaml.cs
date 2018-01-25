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

      
    }
}
