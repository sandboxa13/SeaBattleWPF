using SeaBattleWPF.Core.Models;

namespace SeaBattleWPF.Core.Services
{
    public interface IServerHandlerService
    {
        void Connect();

        void Disconnect();

        void SendData(Message message);

        void ReciveData();

        event ServerHandlerService.MessageDelegate CheckCoordinate;

        event ServerHandlerService.MessageDelegate Shoot;

        event ServerHandlerService.MessageDelegate Miss;  

        event ServerHandlerService.MessageDelegate Message;

        event ServerHandlerService.MessageDelegate Win;
    }
}
