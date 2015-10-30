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
        private static Illustrate illustrate;
        private Connection connection;
        private Illustrate()
        {
            InitializeComponent();
            connection = new Connection();
            textBox1.ReadOnly = true;
           
        }


        public static Illustrate getGUI() {
            if (illustrate == null) {
                illustrate = new Illustrate();
            }

            return illustrate;
        }


      
        private void keyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {
                case Keys.Up:
                    {

                        connection.ConnectToServer("UP#");
                        break;
                    }
                case Keys.Down:
                    {
                        
                        connection.ConnectToServer("DOWN#");  
                        break;
                    }
                case Keys.Right:
                    {

                        connection.ConnectToServer("RIGHT#");
                        break;
                    }
                case Keys.Left:
                    {
                       
                        connection.ConnectToServer("LEFT#");
                        break;
                    }
                case Keys.Space:
                    {
                        connection.ConnectToServer("SHOOT#");
                        break;
                    }
                default:
                    {
                       
                        break;
                    }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_msg(object sender, KeyEventArgs e)
        {
            keyDown(sender,e);
        }


        public  void setTextData(String [,] cells) {
            String txt="";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10 ; j++)
                {
                    txt+=cells[i,j]+"  ";
                }
                txt +=  Environment.NewLine;
            }
            textBox1.Text =txt;
        }

        private void Illustrate_Load(object sender, EventArgs e)
        {

        }
    }
}
