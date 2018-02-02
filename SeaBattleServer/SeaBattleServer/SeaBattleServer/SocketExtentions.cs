using System.IO;
using System.Net.Sockets;
using System.Xml.Serialization;
using SeaBattleServer.ServerLogic;

namespace SeaBattleServer
{
    public static class SocketExtentions
    {
        public static void SendMessage(this Socket socket, Message message)
        {
            var formatter = new XmlSerializer(typeof(Message));
            var stream = new MemoryStream();

            formatter.Serialize(stream, message);

            var msg = stream.ToArray();

            socket?.Send(msg);
        }
    }
}
