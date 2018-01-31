using System.Windows.Input;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattleWPF.Core.Commands;
using SeaBattleWPF.Core.Enums;
using SeaBattleWPF.Core.Services;

namespace SeaBattleWPF.Core.Models
{
    public class Cell
    {
        public int Row { get; }
        public int Column { get; }
        public string Background { get; set; }   
        public CellStateEnum BlockState { get; }

        public ICommand Click { get; }

        public Cell(int r, int c, string color, IServerHandlerService serverHandlerService, CellStateEnum cellStateEnum)
        {
            Row = r;
            Column = c; 
            Background = color;
            BlockState = cellStateEnum;

            Click = new RelayCommand(() =>
            {
                var message = new Message(MessageEnum.Coordinate, Row, Column);

                serverHandlerService.SendData(message);
            });
        }
    }
}
