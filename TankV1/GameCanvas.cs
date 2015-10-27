﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankV1
{
    class GameCanvas

   

    {
        string[,] cells = new string[20,20];
        //
        string[,] bricksCondition;


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


        //When sever notifies that client has succesfully connected
        public void clientConnected(String reply)
        {
            char val = reply.Substring(0, 1)[0];
            switch (val)
            {

                case 'I':
                    this.initialcanvas(reply);
                    this.printCanvas();
                    break;
                case 'S':
                    this.initiatePlayer(reply);
                    this.printCanvas();
                    break;
                case 'G':
                    this.globalUpdate(reply);
                    break;
                default:
                    Console.WriteLine(reply);
                    break;

            }
        }

       //initial point of tank
        public void initiatePlayer(String values) {
            //values = values.Trim('S',':','#','?');
           /* string []val=values.Split(';');
            
            string[] cordinates = val[1].Split(',') ;
            cells[Int32.Parse(cordinates[0]),Int32.Parse(cordinates[1])]=val[0].Split(':')[1];
            Console.WriteLine("val" + val[0].Split(':')[1]);
            */

            //Ru
            String[] val = values.Split(':');
            String[] cordinates = val[2].Split(',') ;
            Console.Write("Lenght of cordinte arr" + cordinates.Length);
            cells[Int32.Parse(cordinates[0]), Int32.Parse(cordinates[1])] = val[1];

        }


        //make initial canvas

        public void initialcanvas(String values) {
            //values = values.Trim(new char[]{'I', '#', '?'});
            //for (int i = 0; i < values.Length;i++ )
            //{
            //    Console.Write(values[i] +"-");
            //}

            //Ru
            String[] val = values.Split(':');
            String[] cordinates;
            String[] xy;
            for (int i = 2; i < 5; i++) {
                //val[2]=Bricks , val[3]= Stone , val[4]=water
                if (i == 4)
                    val[4] = val[4].TrimEnd('#');
                cordinates = val[i].Split(';');
                int count=0;
                for(int j = 0; j < cordinates.Length; j++)
                {
                    xy = cordinates[j].Split(',');
                    switch (j) {
                        case 2:
                            cells[Int32.Parse(xy[0]), Int32.Parse(xy[1])] = "B";
                            this.updateBricks(xy[0], xy[1], "0", count);
                            count++;
                            break;
                        case 3:
                            cells[Int32.Parse(xy[0]), Int32.Parse(xy[1])] = "S";
                            break;
                        case 4:
                            cells[Int32.Parse(xy[0]), Int32.Parse(xy[1])] = "W";
                            break;
                    }
                        
                }

            }
            

        }

        public void globalUpdate(String values)
        {
            String[] val = values.Split(':');
            String[,] playerInfo = new String[5,7];
            String[] temp;

            //Store player infor in a 2D array
            for (int i = 0; i < 5; i++) {
                if ((val[i+1])[0] != 'P')
                    break;
               temp=val[i + 1].Split(';');
                for(int j = 0, j < 7; j++){
                    playerInfo[i, j] = temp[j];
                }

            }

            String[] xy;
            //update canvas according to player position
            for (int i = 0; i < 5; i++) {
                xy = playerInfo[i,1].Split(',');
                cells[Int32.Parse(xy[0]), Int32.Parse(xy[1])] = playerInfo[i,0];
            }
            String bricks = val[(val.Length) - 1];
            val[4] = val[4].TrimEnd('#');
            //update the condition of bricks
            for (int i = 0; i < bricks.Length;i++) {
                //not completed
            }
            
        }

        public void updateBricks(String x, String y, String condition, int count ) {
            String[] temp = new string[3] { x,y,condition};
            for (int i = 0; i < 3; i++) {
                bricksCondition[count, i] = temp[i];
            }
            
        }



   

    }
}
