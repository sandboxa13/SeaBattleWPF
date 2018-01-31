using SeaBattleWPF.Core.ViewModels;

namespace SeaBattleWPF
{
    public class ViewModelLocator
    {   
        public BattleFieldViewModel BattleFieldViewModel => new BattleFieldViewModel(App.MapGeneratorService, App.Navigation, App.ServerHandlerService);

        public MainMenuViewModel MainMenuViewModel => new MainMenuViewModel(App.Navigation);

        public ChatViewModel ChatViewModel => new ChatViewModel();

        public SettingsViewModel SettingsViewModel => new SettingsViewModel(App.Navigation);

        public GameVeiwModel GameVeiwModel => new GameVeiwModel(App.Navigation, App.ServerHandlerService);
    }
}
