using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Serialization;
using SeaBattleWPF.Core.Models;

namespace SeaBattleWPF.Core.Services
{
    public class ServerHandlerService : IServerHandlerService
    {
        private const int Port = 8888;
        private const string Ip = "127.0.0.1";
        private static Socket _socket;  

        public static ServerHandlerService serverHandlerService => serverHandlerService ?? new ServerHandlerService();

        public static bool IsConnected;

        public void Connect()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var ipAddress = IPAddress.Parse(Ip);

            var ipEndPoint = new IPEndPoint(ipAddress, Port);

            _socket.Connect(ipEndPoint);

            if (!_socket.Connected) return;

            var receiveThread = new Thread(ReciveData) { IsBackground = true };
            receiveThread.Start();

            IsConnected = true;
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void SendData(Message message)
        {
            var formatter = new XmlSerializer(typeof(Message));
            var stream = new MemoryStream();
            formatter.Serialize(stream, message);

            _socket.Send(stream.ToArray());
        }

        public void ReciveData()
        {
            while (true)
            {
                var buffer = new byte[4096];
                var bytesReceive = _socket.Receive(buffer);

                if (bytesReceive == 0) continue;

                var stream = new MemoryStream();
                var formatter = new XmlSerializer(typeof(Message));

                stream.Write(buffer, 0, bytesReceive);
                stream.Seek(0, SeekOrigin.Begin);
                var message = (Message)formatter.Deserialize(stream);
            }
        }
    }
}
