using System;
using System.Windows.Input;

namespace SeaBattleWPF
{
    public class BattleFieldCellEventArgs : EventArgs
    {
        public IBattleFieldCell Cell { get; }
        public MouseEventArgs MouseInfo { get; }

        public MouseButton? Button { get; }

        public BattleFieldCellEventArgs(IBattleFieldCell cell, MouseEventArgs mouseInfo)
        {
            Cell = cell;
            MouseInfo = mouseInfo;
            Button = (mouseInfo as MouseButtonEventArgs)?.ChangedButton;
        }
    }
}
