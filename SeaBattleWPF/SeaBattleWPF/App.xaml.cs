using System.Windows;
using SeaBattleWPF.Core.Services;
using SeaBattleWPF.Pages;
using SeaBattleWPF.Services;

namespace SeaBattleWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static NavigationService Navigation;

        public static MapGeneratorService MapGeneratorService;

        public static ServerHandlerService ServerHandlerService;

        protected override void OnStartup(StartupEventArgs e)
        {
            MapGeneratorService = new MapGeneratorService();

            ServerHandlerService = new ServerHandlerService();

            base.OnStartup(e);

            var mainWindow = new MainWindow();
            mainWindow.Show();

            Navigation = new NavigationService(mainWindow.Frame);


            Navigation.Navigate<MainMenu>();
        }
    }
}
