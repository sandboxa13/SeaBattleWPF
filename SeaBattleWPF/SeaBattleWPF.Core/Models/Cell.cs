using System;
using System.Windows.Input;
using SeaBattleWPF.Core.Commands;
using SeaBattleWPF.Core.Enums;
using SeaBattleWPF.Core.Services;

namespace SeaBattleWPF.Core.Models
{
    public class Cell
    {
        public Cell(int r, int c, string color, IServerHandlerService serverHandlerService)
        {
            Row = r;
            Column = c;
            Background = color;

            Click = new RelayCommand(() =>
            {
                var message = new Message(MessageEnum.Coordinate, Row, Column);

                serverHandlerService.SendData(message);
            });
        }

        public int Row { get; }
        public int Column { get; }
        public string Background { get; }

        public ICommand Click { get; }
    }
}
