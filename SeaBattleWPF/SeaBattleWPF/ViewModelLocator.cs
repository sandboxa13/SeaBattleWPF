using SeaBattleWPF.Core.ViewModels;

namespace SeaBattleWPF
{
    public class ViewModelLocator
    {   
        public MainMenuViewModel MainMenuViewModel => new MainMenuViewModel(App.Navigation);

        public SettingsViewModel SettingsViewModel => new SettingsViewModel(App.Navigation);

        public ChatViewModel ChatViewModel => new ChatViewModel();

        public GameVeiwModel GameVeiwModel => new GameVeiwModel(App.Navigation, App.ServerHandlerService, App.MapGeneratorService);

        public LosePageViewModel LosePageViewModel => new LosePageViewModel();

        public WinPageViewModel WinPageViewModel => new WinPageViewModel();
            
    }
}
