using System.Windows;
using SeaBattleWPF.Core.Logic;
using SeaBattleWPF.Core.Logic.Ships.CoordsHelper;

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

            var g = new GenerateRandomCoordsTwoHp(map);

            
            var t = g.GenerateCoords();

            var a = 1;
        }
    }
}
