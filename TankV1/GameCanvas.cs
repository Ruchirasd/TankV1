using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankV1.Canvas_Structure;

namespace TankV1
{
    class GameCanvas

   

    {
        string[,] cells = new string[10,10];
        CanvasStructure[,] cellObjects = new CanvasStructure[10, 10];     
        
        int noOfBricks = 0;
        string[,] bricksCondition; 

        public GameCanvas() {
            //initiate array
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j] = "N";
                    //cellObjects[i, j] = new CanvasStructure();
                    
                }
            }
        }

        public void printCanvas() {
            for (int i = 0; i < 10;i++ )
            {
                for (int j = 0; j < 10;j++ )
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
                    //Console.Write(reply);
                    this.initialcanvas(reply);
                    this.printCanvas();
                    Console.WriteLine();
                    break;
                case 'S':
                    this.initiatePlayer(reply);
                    this.printCanvas();
                    Console.WriteLine();
                    break;
                case 'G':
                    //Console.Write(reply);
                    this.globalUpdate(reply);
                    this.printCanvas();
                    Console.WriteLine();
                    break;
                case 'C':
                    this.coinPile(reply);
                    this.printCanvas();
                    Console.WriteLine();
                    break;
                case 'L':
                    this.lifePackSet(reply);
                    this.printCanvas();
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine(reply);
                    break;

            }
        }

       //initial point of tank
        public void initiatePlayer(String values) {
                      
            String[] val = values.Split(':');
            String[] player = val[1].Split(';');
            String[] cordinates = player[1].Split(',') ;
            //Console.Write("Lenght of cordinte arr" + cordinates.Length);
            cells[Int32.Parse(cordinates[0]), Int32.Parse(cordinates[1])] = player[0];

        }


        //make initial canvas

        public void initialcanvas(String values) {
            
            String[] val = values.Split(':');
            String[] cordinates;
            String[] xy;
            for (int i = 2; i < 5; i++) {
                //val[2]=Bricks , val[3]= Stone , val[4]=water
                if (i == 4)
                    val[4] = val[4].Remove(val[4].Length - 2);
                 
                               
                cordinates = val[i].Split(';');
                
                for(int j = 0; j < cordinates.Length; j++)
                {
                    xy = cordinates[j].Split(',');
                    switch (i) {
                        case 2:
                            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "B";
                            noOfBricks++;
                            break;
                        case 3:
                            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "S";
                            break;
                        case 4:
                            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "W";
                            break;
                        default:
                            Console.Write("Something went wrong in initialization");
                            break;
                    }
                   // Console.Write("no of Bricks" + noOfBricks);  
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
                //Console.Write("Error value check"+val[i + 1][0]);
                if ((val[i+1])[0] != 'P')
                    break;
               temp=val[i + 1].Split(';');
                for(int j = 0; j < 7; j++){
                    playerInfo[i, j] = temp[j];
                }

            }

            String[] xy;
            //update canvas according to player position
            for (int i = 0; i < 5; i++) {
                if (playerInfo[i, 1] == null)
                    break;
                xy = playerInfo[i,1].Split(',');
                cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = playerInfo[i,0];
            }

            String bricksStr = val[(val.Length) - 1];
            bricksStr= bricksStr.Remove(bricksStr.Length - 1);
            String[] brickArr = bricksStr.Split(';');
            bricksCondition = new String[this.noOfBricks, 3];

            //update the condition of bricks
            for (int i = 0; i < brickArr.Length;i++) {
                temp = brickArr[i].Split(',');
                //for (int j = 0; j < 3; j++)
                //    Console.Write("temp variable" + j + "is" + temp[j]);
                this.updateBricks(temp[1], temp[0], temp[2], i);
            }
            
        }

        public void updateBricks(String x, String y, String condition, int count ) {
            String[] temp = new string[3] { x,y,condition};
            for (int i = 0; i < 3; i++)
            {
                //Console.Write("temp variable" + i + "is" + temp[i]);
                bricksCondition[count, i] = temp[i];
            }
                
            
            
        }

        public void coinPile(String values) {
            String[] val = values.Split(':');
            String[] xy = new String[2];
            xy = val[1].Split(',');
            Coin coin = new Coin(xy[1], xy[0], val[2], val[3].Remove(val[3].Length - 2));
            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "C";

        }

        public void lifePackSet(String values) {
            String[] val = values.Split(':');
            String[] xy = new String[2];
            xy = val[1].Split(',');
            LifePack lifePack = new LifePack(xy[1],xy[0], val[2].Remove(val[2].Length - 2));
            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "L";
        }

   

    }
}
