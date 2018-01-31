using SeaBattleWPF.Core.Models;

namespace SeaBattleWPF.Core.Services
{
    public interface IServerHandlerService
    {
        void Connect();

        void Disconnect();

        void SendData(Message message);

        void ReciveData();

        event ServerHandlerService.NewCoordinate CheckCoordinate;
    }
}
