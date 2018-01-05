using System.Windows;
using SeaBattle.Engine.Common;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Common.Players;
using SeaBattle.Engine.Common.Players.AI;

namespace SeaBattleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var player = new Player();
            var computer = new Computer();
            var test = new GameTest(computer, player);

            InitializeComponent();
        }
    }
}
