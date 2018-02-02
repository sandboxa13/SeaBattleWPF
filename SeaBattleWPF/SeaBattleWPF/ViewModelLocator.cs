using SeaBattleWPF.Core.ViewModels;

namespace SeaBattleWPF
{
    public class ViewModelLocator
    {   
        public MainMenuViewModel MainMenuViewModel => new MainMenuViewModel(App.Navigation);

        public ChatViewModel ChatViewModel => new ChatViewModel(App.ServerHandlerService);

        public SettingsViewModel SettingsViewModel => new SettingsViewModel(App.Navigation);

        public GameVeiwModel GameVeiwModel => new GameVeiwModel(App.Navigation, App.ServerHandlerService, App.MapGeneratorService);
    }
}
