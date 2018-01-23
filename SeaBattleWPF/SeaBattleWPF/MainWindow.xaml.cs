using SeaBattle.Engine.Common.AI;
using SeaBattleWPF.GameControls;
using System.Windows;
using System.Windows.Media;

namespace SeaBattleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Computer _computer;

        public MainWindow()
        {
            InitializeComponent();

            _computer = new Computer(Player.Map);

            

            Computer.OnBattleFieldCellMouseEnter += Field_OnBattleFieldCellMouseEnter;
            Computer.OnBattleFieldCellMouseLeave += Field_OnBattleFieldCellMouseLeave;
            Computer.OnBattleFieldCellMouseUp += Field_OnBattleFieldCellMouseUp;

            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    Computer.fieldCell[x, y].Control.Background = Brushes.CornflowerBlue;
                }
            }
        }


        private void CheckOnShoot(FieldCell cell)
        {
            if (Computer.Map.MapBlocks[cell.X, cell.Y].X == cell.X && Computer.Map.MapBlocks[cell.X, cell.Y].Y == cell.Y && Computer.Map.MapBlocks[cell.X, cell.Y].State == SeaBattle.Engine.Common.MapLogic.BlockState.IsShip)
            {
                Computer.fieldCell[cell.X, cell.Y].Control.Background = Brushes.Black;
            }

            else
            {
                var computerCoord = _computer.GenerateCoord();

                Player.fieldCell[computerCoord.X, computerCoord.Y].Control.Background = Brushes.Black;
            }
        }

        #region Events Handle

        private void Field_OnBattleFieldCellMouseUp(object sender, BattleFieldCellEventArgs e)
        {
            CheckOnShoot(e.Cell);
        }

        private void Field_OnBattleFieldCellMouseLeave(object sender, BattleFieldCellEventArgs e)
        {
        }

        private void Field_OnBattleFieldCellMouseEnter(object sender, BattleFieldCellEventArgs e)
        {

        }

        #endregion
    }
}
