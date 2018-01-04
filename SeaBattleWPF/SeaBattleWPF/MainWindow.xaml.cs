using System.Windows;
using SeaBattle.Engine.Common;
using SeaBattle.Engine.Common.MapLogic;

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

            var map = new GameTest();

            

            //var t = g.GenerateCoords();
        }
    }
}
