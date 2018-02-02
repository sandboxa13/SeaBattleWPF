using System.Collections.Generic;
using System.Linq;
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

        private readonly IServerHandlerService _serverHandlerService;

        #endregion

        #region Public Members  

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

        #endregion

        #region Constructor

        public GameVeiwModel(
            INavigationService navigationService,
            IServerHandlerService serverHandlerService,
            IMapGeneratorService mapGeneratorService)
        {
            _serverHandlerService = serverHandlerService;

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

            _serverHandlerService.CheckCoordinate += _serverHandlerService_CheckCoordinate;
            _serverHandlerService.Shoot += _serverHandlerService_Shoot;
            _serverHandlerService.Miss += _serverHandlerService_Miss;
        }

        #endregion

        #region Event Handlers

        private void _serverHandlerService_Miss(Message message)
        {
            IsEnabled = false;

            OnPropertyChanged(nameof(IsEnabled));

            var numbers = message.message.Split(' ').Select(int.Parse).ToList();

            _enemyCells[numbers[0], numbers[1]].Background = "White";

            OnPropertyChanged(nameof(EnemyCells));

        }

        private void _serverHandlerService_Shoot(Message message)
        {
            IsEnabled = true;
            OnPropertyChanged(nameof(IsEnabled));

            var numbers = message.message.Split(' ').Select(int.Parse).ToList();

            _enemyCells[numbers[0], numbers[1]].Background = "Red";

            OnPropertyChanged(nameof(EnemyCells));

        }

        private void _serverHandlerService_CheckCoordinate(Message message)
        {
            var numbers = message.message.Split(' ').Select(int.Parse).ToList();

            if (_playerCells[numbers[0], numbers[1]].BlockState == CellStateEnum.IsShip)
            {
                IsEnabled = false;
                OnPropertyChanged(nameof(IsEnabled));

                var newMessage = new Message(MessageEnum.Shoot, numbers[0], numbers[1]);

                _serverHandlerService.SendData(newMessage);

                _playerCells[numbers[0], numbers[1]].Background = "Red";

                OnPropertyChanged(nameof(PlayerCells));
            }

            else
            {
                IsEnabled = true;
                OnPropertyChanged(nameof(IsEnabled));

                var newMessage = new Message(MessageEnum.Miss, numbers[0], numbers[1]);

                _serverHandlerService.SendData(newMessage);
            }
        }

        #endregion
    }
}
