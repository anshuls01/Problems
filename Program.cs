using System;
namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World!");
            int TC = Convert.ToInt32(Console.ReadLine());
            while (TC > 0)
            {
                //PillsvsGerms.PillsvsGerms.CountRemainingGerms();
                PillsvsGerms.PillsvsGermsDFS.CountRemainingGerms();
                TC--;
            }
            Console.ReadLine();
        }
    }
}
