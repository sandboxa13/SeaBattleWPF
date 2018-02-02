using SeaBattleWPF.Core.Services;
using SeaBattleWPF.Core.Models;

namespace SeaBattleWPF.Core.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public string Message { get; set; }

        public ChatViewModel(IServerHandlerService serverHandlerService)
        {

        }      
    }
}
