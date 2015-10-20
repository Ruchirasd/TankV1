using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TankV1.Client
{
    class Connection
    {
        public const string SERVER_IP = "localhost";
        public const int SERVER_PORT = 7000;
        private BinaryWriter writer;
        private const string CLIENT_IP = "localhost";
        private const string CLIENT_PORT = "6000";

        private TcpClient client;
        private TcpListener listner;
        private NetworkStream serverStream; 

        public void ReceiveData() {
                listner = new TcpListener(IPAddress.Parse(SERVER_IP),SERVER_PORT);
                listner.Start();
                Console.Write("Server started.....");

                
               

            }


        public void ConnectToServer() {
            DataObject dataObj;

            client = new TcpClient();
            client.Connect(CLIENT_IP,CLIENT_PORT);
        }

     }
}

