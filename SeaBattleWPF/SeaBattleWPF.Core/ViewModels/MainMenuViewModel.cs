using System.Threading.Tasks;
using System.Windows.Input;
using SeaBattleWPF.Core.Commands;
using SeaBattleWPF.Core.Services;

namespace SeaBattleWPF.Core.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        #region Public Commands

        /// <summary>
        /// Go to page with choise game (singleplayer or multiplayer)
        /// </summary>
        public ICommand StartGameCommand { get; }


        /// <summary>
        /// Go to settings page
        /// </summary>
        public ICommand SettingsCommand { get; }


        /// <summary>
        /// Exit from application
        /// </summary>
        public ICommand ExitCommand { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="navigationService">navigation service</param>
        public MainMenuViewModel(INavigationService navigationService)
        {
            StartGameCommand = new RelayCommand(() => navigationService.Navigate("GamePage"));

            SettingsCommand = new RelayCommand(() => navigationService.Navigate("SettingsPage"));

            ExitCommand = new RelayCommand(() => Task.Delay(0));
        }

        #endregion
    }
}
