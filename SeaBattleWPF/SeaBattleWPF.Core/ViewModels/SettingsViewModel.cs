using System.Windows.Input;
using SeaBattleWPF.Core.Commands;
using SeaBattleWPF.Core.Services;

namespace SeaBattleWPF.Core.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; }  

        public SettingsViewModel(INavigationService navigationService)
        {
            GoBackCommand = new RelayCommand(() => navigationService.Navigate("MainMenu"));

        }
    }
}
