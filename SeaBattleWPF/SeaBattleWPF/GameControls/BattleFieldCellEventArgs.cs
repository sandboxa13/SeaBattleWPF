using System.Windows.Input;

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
}
