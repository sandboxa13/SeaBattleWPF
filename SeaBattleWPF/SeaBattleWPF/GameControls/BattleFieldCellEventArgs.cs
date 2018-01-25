using System.Windows.Input;
using SeaBattleWPF.ViewModels;

namespace SeaBattleWPF.GameControls
{
    /// <summary>
    /// Interaction logic for Field.xaml
    /// </summary>
    /// 
    public class BattleFieldCellEventArgs : System.EventArgs
    {
        public CellViewModel Cell { get; private set; }
        public MouseEventArgs MouseInfo { get; private set; }

        public MouseButton? Button { get; private set; }

        public BattleFieldCellEventArgs(CellViewModel cell, MouseEventArgs mouseInfo)
        {
            Cell = cell;
            MouseInfo = mouseInfo;
            Button = (mouseInfo as MouseButtonEventArgs)?.ChangedButton;
        }
    }
}
