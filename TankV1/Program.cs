using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace TankV1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Console.WriteLine("1");

            Connection c = new Connection();
           // c.ConnectToServer();
           // c.ReceiveData();

            //Test t = new Test();
            Illustrate i = new Illustrate();
            i.Show();


        }
    }
}
