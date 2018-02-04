using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using SeaBattleWPF.Core.Commands;
using SeaBattleWPF.Core.Enums;
using SeaBattleWPF.Core.Models;
using SeaBattleWPF.Core.Services;

namespace SeaBattleWPF.Core.ViewModels
{
    public class GameVeiwModel : BaseViewModel
    {
        #region Private Members

        private readonly Cell[,] _playerCells;

        private readonly Cell[,] _enemyCells;

        private CustomObservableCollection<string> _messages;

        private readonly IServerHandlerService _serverHandlerService;

        private readonly INavigationService _navigationService;

        private readonly Dispatcher _dispatcher;

        private string _message;


        #endregion  

        #region Public Members  

        public CustomObservableCollection<string> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }

        public ICommand Send { get; set; }

        public string Message
        {
            get => _message;

            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public bool IsEnabled { get; set; } = true;

        public IEnumerable<Cell> PlayerCells
        {
            get => _playerCells.Cast<Cell>();

            set => OnPropertyChanged(nameof(PlayerCells));
        }

        public IEnumerable<Cell> EnemyCells
        {
            get => _enemyCells.Cast<Cell>();

            set => OnPropertyChanged(nameof(EnemyCells));
        }

        public int Hp { get; set; } = 16;

        #endregion

        #region Constructor

        public GameVeiwModel(
            INavigationService navigationService,
            IServerHandlerService serverHandlerService,
            IMapGeneratorService mapGeneratorService)
        {
            _serverHandlerService = serverHandlerService;
            _navigationService = navigationService;
            _messages = new CustomObservableCollection<string>();
            Messages = _messages;
            _dispatcher = Dispatcher.CurrentDispatcher;

            _playerCells = new Cell[10, 10];

            _playerCells = mapGeneratorService.GenerateMap();

            PlayerCells = _playerCells.Cast<Cell>();


            _enemyCells = new Cell[10, 10];

            _enemyCells = mapGeneratorService.GenerateMap(serverHandlerService);

            EnemyCells = _enemyCells.Cast<Cell>();

            foreach (var enemyCell in EnemyCells)
            {
                enemyCell.Background = "Black";
            }

            Send = new RelayCommand(() =>
            {
                var mesage = new Message(MessageEnum.Message, Message);
                _serverHandlerService.SendData(mesage);
            });

            _serverHandlerService.CheckCoordinate += _serverHandlerService_CheckCoordinate;
            _serverHandlerService.Shoot += _serverHandlerService_Shoot;
            _serverHandlerService.Miss += _serverHandlerService_Miss;
            _serverHandlerService.Win += _serverHandlerService_Win;
            _serverHandlerService.Message += _serverHandlerService_Message;
        }

        private void _serverHandlerService_Message(Message message)
        {
            _messages.Add(message.Info + " : " + message.message);
        }

        private void _serverHandlerService_Win(Message message)
        {
            _dispatcher.Invoke(() =>
            {
                _navigationService.Navigate("WinPage"); 
            });
        }

        #endregion

        #region Event Handlers

        private void _serverHandlerService_Miss(Message message)
        {
            IsEnabled = false;

            var numbers = message.message.Split(' ').Select(int.Parse).ToList();

            _enemyCells[numbers[0], numbers[1]].Background = "White";

            _messages.Add(message.Info + " : " + message.message);


            OnPropertyChanged(nameof(IsEnabled));
            OnPropertyChanged(nameof(EnemyCells));
            OnPropertyChanged(nameof(Messages));
        }

        private void _serverHandlerService_Shoot(Message message)
        {
            IsEnabled = true;

            if (message.message == null) return;

            var numbers = message.message.Split(' ').Select(int.Parse).ToList();

            _enemyCells[numbers[0], numbers[1]].Background = "Red";

            _messages.Add(message.Info + " : " + message.message);


            OnPropertyChanged(nameof(IsEnabled));
            OnPropertyChanged(nameof(EnemyCells));
            OnPropertyChanged(nameof(Messages));
        }

        private void _serverHandlerService_CheckCoordinate(Message message)
        {
            var numbers = message.message.Split(' ').Select(int.Parse).ToList();

            if (_playerCells[numbers[0], numbers[1]].BlockState == CellStateEnum.IsShip)
            {
                IsEnabled = false;          

                var newMessage = new Message(MessageEnum.Shoot, numbers[0], numbers[1]);

                _serverHandlerService.SendData(newMessage);

                _playerCells[numbers[0], numbers[1]].Background = "Gray";

                _messages.Add(message.Info + " : " + message.message);

                Hp--;

                CheckWin();

                OnPropertyChanged(nameof(Messages));
                OnPropertyChanged(nameof(IsEnabled));
                OnPropertyChanged(nameof(PlayerCells));
            }

            else
            {
                IsEnabled = true;

                _playerCells[numbers[0], numbers[1]].Background = "White";

                var newMessage = new Message(MessageEnum.Miss, numbers[0], numbers[1]);

                _serverHandlerService.SendData(newMessage);
                _messages.Add(message.Info + " : " + message.message);


                OnPropertyChanged(nameof(PlayerCells));
                OnPropertyChanged(nameof(IsEnabled));
                OnPropertyChanged(nameof(Messages));
            }
        }

        private void CheckWin()
        {
            if (Hp != 0) return;

            _dispatcher.Invoke(() =>
            {
                var message = new Message(MessageEnum.Win);
                 _serverHandlerService.SendData(message);
                 _navigationService.Navigate("LosePage");
            });       
        }

        #endregion
    }
}
