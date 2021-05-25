using System;
using System.Threading.Tasks;

namespace AwaitAndAsync
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintName();
            PrintSum(1, 2);
            Console.WriteLine("Third line");
            Console.WriteLine("Fourth Line");
            Console.ReadLine();
        }





        static void PrintName()
        {
            Console.WriteLine("Nahid Evan");
        }


        static async Task PrintSum(int a, int b)
        {

            await Task.Run(()=>Console.WriteLine("Sum : " + (a + b)));

        }
    }

}