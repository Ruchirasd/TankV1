using System;
using System.Threading;





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

            Connection c = new Connection();
            c.ConnectToServer("JOIN#");


            Thread t = new Thread(runGUI);
            t.Start();

            c.ReceiveData();

            //Test t = new Test();
            


        }

        static void runGUI(){

            Illustrate i = Illustrate.getGUI();
            i.ShowDialog();
        }
    }
}
