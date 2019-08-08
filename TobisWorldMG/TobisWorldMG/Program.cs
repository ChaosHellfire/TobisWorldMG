using System;

namespace TobisWorldMG
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                CommandService.DoCommand(input);
            }
        }
    }
}
