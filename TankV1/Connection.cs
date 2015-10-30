using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TankV1
{
    class Connection
    {
        public const string SERVER_IP = "127.0.0.1";
        public const int SERVER_PORT = 7000;
        private   BinaryWriter writer;
        private const string CLIENT_IP = "localhost";
        private const int CLIENT_PORT = 6000;
        private static GameCanvas g = new GameCanvas();
        private  TcpClient client;
        private TcpListener listner;
        private NetworkStream serverStream; 

        public void  ReceiveData() {
            listner = new TcpListener(IPAddress.Parse(SERVER_IP), SERVER_PORT);
            
                listner.Start();
                Console.Write("Server started.....");

                Socket connection;
               
                while (true)
                {
                    //connection is connected socket
                    connection = listner.AcceptSocket();
                    if (connection.Connected)
                    {

                        this.serverStream = new NetworkStream(connection);

                        SocketAddress sockAdd = connection.RemoteEndPoint.Serialize();
                        string s = connection.RemoteEndPoint.ToString();
                        List<Byte> inputStr = new List<byte>();

                        int asw = 0;
                        while (asw != -1)
                        {
                            asw = this.serverStream.ReadByte();
                            inputStr.Add((Byte)asw);
                        }

                        String reply = Encoding.UTF8.GetString(inputStr.ToArray());

                    //Console.Write(reply);
                        
                        this.serverStream.Close();
                    switch (reply) {
                        case "PLAYERS_FULL#":
                            Console.Write("PLAYERS_FULL");
                            break;
                        case "ALREADY_ADDED#":
                            Console.Write("ALREADY_ADDED");
                            break;
                        case "GAME_ALREADY_STARTED#":
                            Console.Write("GAME_ALREADY_STARTED");
                            break;
                        case "OBSTACLE#":
                            Console.Write("OBSTACLE");
                            break;
                        case "CELL_OCCUPIED#":
                            Console.Write("CELL_OCCUPIED");
                            break;
                        case "DEAD#":
                            Console.Write("DEAD");
                            break;
                        case "TOO_QUICK#":
                            Console.Write("TOO_QUICK");
                            break;
                        case "GAME_HAS_FINISHED#":
                            Console.Write("GAME_HAS_FINISHED");
                            break;
                        case "GAME_NOT_STARTED_YET#":
                            Console.Write("GAME_NOT_STARTED_YET");
                            break;
                        case "INVALID_CELL#":
                            Console.Write("INVALID_CELL");
                            break;
                        default:
                            g.clientConnected(reply);
                            break;
                              
                    }
                       
                        
                       
                    }
                }

                
               

            }


        public  void ConnectToServer(String msg)
        {

            try
            {
                client = new TcpClient();
                client.Connect(CLIENT_IP, CLIENT_PORT);
                writer = new BinaryWriter(client.GetStream());
                Byte[] tempStr = Encoding.ASCII.GetBytes(msg);
                writer.Write(tempStr);
                client.Close();
                if (client.Connected)
                {
                    Console.WriteLine("connected......");
                }

            }catch(SocketException e){
                Console.WriteLine("unable to connect server");
            
            }
            
        }


        

     }
}

