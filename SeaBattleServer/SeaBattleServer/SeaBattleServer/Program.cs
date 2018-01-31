using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace SeaBattleServer
{
    public class Program
    {
        private static readonly int _port = 8888;
        private static readonly string _ip = "127.0.0.1";
        private static Socket _serverSocket;
        public static List<Socket> Clients = new List<Socket>();

        public static void Main()
        {
            var id = 0;
            try
            {
                var address = IPAddress.Parse(_ip);

                _serverSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(address, _port));
                _serverSocket.Listen(100);

                while (true)
                {
                    var handle = _serverSocket.Accept();
                    var client = new Client(handle, id);
                    Console.WriteLine($"Client with id - {id} connected");
                    id++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
