using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankV1
{
    class GameCanvas

   

    {
        string[,] cells = new string[20,20];


        public GameCanvas() {
            //initiate array
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    cells[i, j] = "N";
                    
                }
            }
        }

        public void printCanvas() {
            for (int i = 0; i < 20;i++ )
            {
                for (int j = 0; j < 20;j++ )
                {
                    Console.Write(cells[i, j]+" ");
                }
                Console.WriteLine();
            }
        
        }

       //initial point of tank
        public void initiatePlayer(String values) {
            //values = values.Trim('S',':','#','?');
            string []val=values.Split(';');
            
            string[] cordinates = val[1].Split(',') ;
            cells[Int32.Parse(cordinates[0]),Int32.Parse(cordinates[1])]=val[0].Split(':')[1];
            Console.WriteLine("val" + val[0].Split(':')[1]);
        }


        //make initial canvas

        public void initialcanvas(String values) {
            values = values.Trim(new char[]{'I', '#', '?'});
            for (int i = 0; i < values.Length;i++ )
            {
                Console.Write(values[i] +"-");
            }
        }
    }
}
