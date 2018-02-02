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
                case MessageEnum.Miss:
                    SendMissInfoToPlayer(message);
                    break;  
                case MessageEnum.Shoot:
                    SendShootInfoToPlayer(message);
                    break;
            }
        }


        private void SendShootInfoToPlayer(Message message)
        {
            var getClient = Program.Clients.FirstOrDefault(x => x != UserSocket);
            getClient.SendMessage(new Message(MessageEnum.Shoot, message.message));
        }

        private void SendMissInfoToPlayer(Message message)
        {
            var getClient = Program.Clients.FirstOrDefault(x => x != UserSocket);
            getClient.SendMessage(new Message(MessageEnum.Miss, message.message));
        }

        private void SendCoordinateToSecondPlayer(Message message)
        {
            var getClient = Program.Clients.FirstOrDefault(x => x != UserSocket);

            var formatter = new XmlSerializer(typeof(Message));
            var stream = new MemoryStream();

            formatter.Serialize(stream, message);

            var msg = stream.ToArray();

            getClient?.Send(msg);
        }        
    }
}
