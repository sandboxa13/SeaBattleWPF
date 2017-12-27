using System.Windows;
using SeaBattleWPF.Core.Logic;

namespace SeaBattleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var map = new Map();

            var g = new GenerateRandomCoords(map);

            g.GenerateCoordForTwoHpShip();
        }
    }
}
