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
        #region Private Members

        //TO:DO allow user to write his port and ip
        private const int Port = 8888;
        private const string Ip = "25.29.220.228";
        private static Socket _socket;

        /// <summary>
        /// Instanse of the ServerHadnleService(because we need one connect to our server)
        /// </summary>
        private static ServerHandlerService _instance;

        #endregion

        #region Public Members

        /// <summary>
        /// Is there a connection to the server or not
        /// </summary>
        public static bool IsConnected; 

        public delegate void MessageDelegate(Message message);

        public event MessageDelegate NewMessage;

        #endregion

        #region Contsructor

        /// <summary>
        /// Private constroctor (singleton)
        /// </summary>
        private ServerHandlerService()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get instanse of the ServerHandleService
        /// </summary>
        /// <returns></returns>
        public static ServerHandlerService GetInstance()
        {
            return _instance ?? (_instance = new ServerHandlerService());
        }


        /// <summary>
        /// Method to connect to the server
        /// </summary>
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

        /// <summary>
        /// Method to disconnect from the server
        /// </summary>
        public void Disconnect()
        {
            //TO DO add disconnect function
        }

        /// <summary>
        /// Method to send data to the server
        /// </summary>
        /// <param name="message"></param>
        public void SendData(Message message)
        {
            var formatter = new XmlSerializer(typeof(Message));
            var stream = new MemoryStream();
            formatter.Serialize(stream, message);

            _socket.Send(stream.ToArray());
        }

        /// <summary>
        /// Method to recive data from server
        /// </summary>
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

                NewMessage?.Invoke(message);              
            }
        }

        #endregion
    }
}
