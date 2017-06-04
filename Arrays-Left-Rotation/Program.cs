//Arrays Left Rotation
//Marton Kis-Varday 
//2017
using System;
using System.Collections.Generic;

namespace Arrays_Left_Rotation
{
    class Program
    {
        static void Main(String[] args)
        {
            //Get input
            var tokens_n = Console.ReadLine().Split(' ');

            var n = Convert.ToInt32(tokens_n[0]);
            var k = Convert.ToInt32(tokens_n[1]);

            var arrayRead = Console.ReadLine().Split(' ');

            //Make array
            var array = Array.ConvertAll(arrayRead, Int32.Parse);

            //Make queue from array
            var queue = new Queue<int>(array);

            //Perform rotation
            for (var i = 0; i < k; i++)
            {
                var num = queue.Dequeue();
                queue.Enqueue(num);
            }

            //Log result
            foreach (var number in queue)
            {
                Console.Write(number + " ");
            }
        }
    }
}
