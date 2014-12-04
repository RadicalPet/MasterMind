using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }
        static void Init()
        {
            ConsoleKeyInfo input;

            
            do
            {
                Console.Write("Press Enter to start!\n");  
                input = Console.ReadKey();
                Console.Write("\n");
            } 
            while (input.Key != ConsoleKey.Enter);
   
        }

    }
}
