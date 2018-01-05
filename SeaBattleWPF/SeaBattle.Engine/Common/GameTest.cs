using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Common.Players;
using SeaBattle.Engine.Common.Players.AI;

namespace SeaBattle.Engine.Common
{
    public class GameTest
    {
        private readonly Player _player;

        private readonly Computer _computer;


        public GameTest(Computer computer, Player player)
        {
            _computer = computer;
            _player = player;
        }

        private void CheckOnWin(Coords coord, Player player)
        {
            if (player == _player && !_player.Win )
            {
                
            }
            if (_computer.Win)
            {
                // TODO logic for handle _computer win
            }   



        }
    }
}
