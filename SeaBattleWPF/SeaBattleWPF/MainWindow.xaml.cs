using System.Windows;

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
        }
    }
}
