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
            int[] secretArray = new int[] { 1, 2, 3, 4 };
            int[] userGuessesArray = new int[] { 0, 0, 0, 0 };

            bool won = false;
            int tries = 1;

            Init();
            SetSecretInts(ref secretArray);
            Console.Write("{0} {1} {2} {3}", secretArray[0], secretArray[1], secretArray[2], secretArray[3]);
            Console.Write("\n");

            while (won == false)
            {
                GetUserInput(ref userGuessesArray);
                int[] resultArray = CheckForExactMatches(secretArray, userGuessesArray);
                resultArray = CheckForMatches(secretArray, userGuessesArray, resultArray);

                if (Array.IndexOf(resultArray, 0) == -1 && Array.IndexOf(resultArray, 1) == -1)
                {
                    won = true;
                    Console.Write("\n");
                    Console.WriteLine("You won! This took you {0} tries.", tries);
                }
                else
                {
                    tries++;
                    Console.WriteLine(ResultsAsString(resultArray));
                    Console.Write("\n");
                }
            }
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
            Console.Write("[][][][]");
            Console.Write("\n");
        }
        static void SetSecretInts(ref int[] secretArray)
        {
            Random rnd = new Random();
            for (int i = 0; i < secretArray.Length; i++)
            {
                secretArray[i] = rnd.Next(1, 7);
            }
        }
        static void GetUserInput(ref int[] userGuessesArray)
        {
            string userGuessesString = Console.ReadLine();
            userGuessesArray = Array.ConvertAll(userGuessesString.ToCharArray(), c => (int)Char.GetNumericValue(c));
        }
        static string ResultsAsString(int[] resultArray)
        {
            resultArray = resultArray.OrderByDescending(c => c).ToArray();
            StringBuilder result = new StringBuilder();
            foreach (var item in resultArray)
            {
                if (item == 0)
                {
                    result.Append("[?]");
                }
                else if (item == 1)
                {
                    result.Append("[/]");
                }
                else if (item == 2)
                {
                    result.Append("[X]");
                }
            }
            return result.ToString();
        }
        static int[] CheckForExactMatches(int[] secretArray, int[] userGuessesArray)
        {
            int[] resultArray = new int[4];

            for (int i = 0; i < secretArray.Length; i++){
                if (secretArray[i] == userGuessesArray[i])
                {
                    resultArray[i] = 2;
                }
            }
            return resultArray;
        }
        static int[] CheckForMatches(int[] secretArray, int[] userGuessesArray, int[] resultArray)
        {
            var query = from a in secretArray
                        from b in userGuessesArray
                        select new { a, b };

            query = query.AsEnumerable().ToArray();

            double i = 0;
            foreach (var x in query)
            {
                int y = (int)Math.Floor(i);
                if (x.a == x.b)
                {
                    if (resultArray[y] != 2)
                    {
                        resultArray[y] = 1;
                    }
                }
                i = i + 0.25;
            }
            return resultArray;
        }
    }
}