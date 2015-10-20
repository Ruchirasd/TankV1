using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TankV1.Client
{
    class Connection
    {
        public const string SERVER_IP = "localhost";
        public const int SERVER_PORT = 7000;
        private BinaryWriter writer;

        private TcpListener listner;
        private NetworkStream serverStream; 

        public void ReceiveData() {
                listner = new TcpListener(IPAddress.Parse(SERVER_IP),SERVER_PORT);
                listner.Start();
                Console.Write("Server started.....");
               

            }

     }
}

