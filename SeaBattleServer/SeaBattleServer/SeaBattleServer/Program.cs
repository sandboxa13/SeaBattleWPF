using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace SeaBattleServer
{
    public class Program
    {
        private const int Port = 8888;
        private const string Ip = "127.0.0.1";
        private static Socket _serverSocket;
        public static List<Socket> Clients = new List<Socket>();
            
        public static void Main()
        {
            var id = 0;
            try
            {
                var address = IPAddress.Parse(Ip);

                _serverSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(address, Port));
                _serverSocket.Listen(100);

                Console.WriteLine($"INFO : server started on ip : {Ip} port : {Port}");
                Console.WriteLine("INFO : Waiting for clients");

                while (true)
                {
                    var handle = _serverSocket.Accept();
                    var client = new Client(handle, id);
                    Console.WriteLine($"New client from ip {handle.RemoteEndPoint} connected");
                    Clients.Add(handle);
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
