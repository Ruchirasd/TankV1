using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TankV1
{
    public partial class Illustrate : Form
    {
        public Illustrate()
        {
            InitializeComponent();
        }



      
        private void keyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {
                case Keys.Up:
                    {

                        try
                        {
                            TcpClient client = new TcpClient();
                            client.Connect("127.0.0.1", 6000);
                            BinaryWriter writer = new BinaryWriter(client.GetStream());
                            Byte[] tempStr = Encoding.ASCII.GetBytes("UP#");
                            writer.Write(tempStr);
                            client.Close();
                            if (client.Connected)
                            {
                                Console.WriteLine("connected......");
                            }

                        }
                        catch (SocketException a)
                        {
                            Console.WriteLine("unable to connect server");

                        }
                        MessageBox.Show("you pressed uparroow");
                        break;
                    }
                case Keys.Down:
                    {


                        try
                        {
                            TcpClient client = new TcpClient();
                            client.Connect("127.0.0.1", 6000);
                            BinaryWriter writer = new BinaryWriter(client.GetStream());
                            Byte[] tempStr = Encoding.ASCII.GetBytes("DOWN#");
                            writer.Write(tempStr);
                            client.Close();
                            if (client.Connected)
                            {
                                Console.WriteLine("connected......");
                            }

                        }
                        catch (SocketException a)
                        {
                            Console.WriteLine("unable to connect server");

                        }
                        MessageBox.Show("you pressed down arrow");
                        break;
                    }
                case Keys.Right:
                    {
                        try
                        {
                            TcpClient client = new TcpClient();
                            client.Connect("127.0.0.1", 6000);
                            BinaryWriter writer = new BinaryWriter(client.GetStream());
                            Byte[] tempStr = Encoding.ASCII.GetBytes("RIGHT#");
                            writer.Write(tempStr);
                            client.Close();
                            if (client.Connected)
                            {
                                Console.WriteLine("connected......");
                            }

                        }
                        catch (SocketException a)
                        {
                            Console.WriteLine("unable to connect server");

                        }
                        MessageBox.Show("you pressed right");
                        break;
                    }
                case Keys.Left:
                    {
                        try
                        {
                            TcpClient client = new TcpClient();
                            client.Connect("127.0.0.1", 6000);
                            BinaryWriter writer = new BinaryWriter(client.GetStream());
                            Byte[] tempStr = Encoding.ASCII.GetBytes("LEFT#");
                            writer.Write(tempStr);
                            client.Close();
                            if (client.Connected)
                            {
                                Console.WriteLine("connected......");
                            }

                        }
                        catch (SocketException a)
                        {
                            Console.WriteLine("unable to connect server");

                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("you pressed " + e.KeyData);
                        break;
                    }
            }
        }
    }
}
