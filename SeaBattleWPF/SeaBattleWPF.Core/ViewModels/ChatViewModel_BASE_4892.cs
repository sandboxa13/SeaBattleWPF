using SeaBattleWPF.Core.Services;
using SeaBattleWPF.Core.Models;

namespace SeaBattleWPF.Core.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public string Message { get; set; }

        public ChatViewModel(IServerHandlerService serverHandlerService)
        {
            serverHandlerService.Message += ServerHandlerService_Message;
            serverHandlerService.Shoot += ServerHandlerService_Shoot;
        }

        private void ServerHandlerService_Shoot(Message message)
        {
            Message = message.message;
            OnPropertyChanged(nameof(Message));
        }

        private void ServerHandlerService_Message(Message message)
        {
            Message = message.message;
            OnPropertyChanged(nameof(Message));
        }
    }
}
