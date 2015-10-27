using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankV1
{
    class Test
    {
        public Test() {
            String str = "S:frt:456:k;56;dfg:78#";
            Console.Write(str);
            Console.WriteLine();
            if(str[0]=='S')
                Console.Write("Yes ");
            Console.Write(str.TrimEnd('#'));
            String[] arr = str.Split(';');
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    Console.Write(arr[j] + " next");
            //}
            Console.WriteLine();
        }
    }
}
