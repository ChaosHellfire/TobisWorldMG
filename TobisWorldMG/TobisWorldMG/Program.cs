using System;

namespace TobisWorldMG
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICh möchte hier eine änderung vornehmen
            while (true)
            {
                string input = Console.ReadLine();
                CommandService.DoCommand(input);
            }
        }
    }
}
