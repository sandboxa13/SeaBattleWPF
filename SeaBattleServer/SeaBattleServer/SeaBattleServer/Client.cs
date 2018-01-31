using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Serialization;
using SeaBattleServer.ServerLogic;

namespace SeaBattleServer
{
    public class Client
    {
        public Socket UserSocket { get; }
        private readonly int _id;

        public Client(Socket handle, int id)
        {
            Program.Clients.Add(handle);

            _id = id;
            UserSocket = handle;
            var userThread = new Thread(Listner) { IsBackground = true };
            userThread.Start();
        }

        private void Listner()
        {
            try
            {
                while (UserSocket.Connected)
                {
                    var buffer = new byte[4096];
                    var bytesReceive = UserSocket.Receive(buffer);

                    var stream = new MemoryStream();
                    var formatter = new XmlSerializer(typeof(Message));

                    stream.Write(buffer, 0, bytesReceive);
                    stream.Seek(0, SeekOrigin.Begin);
                    var message = (Message)formatter.Deserialize(stream);

                    Console.WriteLine($"info {message.Info}  message {message.message} id {_id}");

                    Process(message);
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Client {UserSocket.RemoteEndPoint} disconnected!");
                Program.Clients.Remove(UserSocket);
            }
        }

        private void Process(Message message)
        {
            switch (message.Info)
            {
                case MessageEnum.Coordinate:
                    SendCoordinateToSecondPlayer(message);
                    break;
                case MessageEnum.Message:
                    break;
            }   
        }

        private void SendCoordinateToSecondPlayer(Message message)
        {
            foreach (var client in Program.Clients)
            {
                var formatter = new XmlSerializer(typeof(Message));
                var stream = new MemoryStream();

                formatter.Serialize(stream, message);

                var msg = stream.ToArray();

                client?.Send(msg);
            }     
        }
    }
}