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
            int[] userGuessesArray = new int[] {0, 0, 0, 0};

            bool won = false;

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
                    Console.WriteLine("won");
                }
                else
                {
                    Console.WriteLine(resultsAsString(resultArray));
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
        static void SetSecretInts(ref int [] secretArray)
        {
            Random rnd = new Random();
            int one = rnd.Next(1, 6);
            int two = rnd.Next(1, 6);
            int three = rnd.Next(1, 6);
            int four = rnd.Next(1, 6);

            secretArray[0] = one;
            secretArray[1] = two;
            secretArray[2] = three;
            secretArray[3] = four;
        
        }
        static void GetUserInput(ref int [] userGuessesArray)
        {
            string userGuessesString = Console.ReadLine();
            userGuessesArray = Array.ConvertAll(userGuessesString.ToCharArray(), c => (int)Char.GetNumericValue(c)); 
        }
        static string resultsAsString(int[] resultArray)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in resultArray)
            {
                if (item == 0)
                {
                    result.Append("[?]");
                }
                else if (item == 1){
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

            if (secretArray[0] == userGuessesArray[0])
            {
                resultArray[0] = 2;
            }
            if (secretArray[1] == userGuessesArray[1])
            {
                resultArray[1] = 2;
            }
            if (secretArray[2] == userGuessesArray[2])
            {
                resultArray[2] = 2;
            }
            if (secretArray[3] == userGuessesArray[3])
            {
                resultArray[3] = 2;
            }
            return resultArray;
        }
        static int[] CheckForMatches(int[] secretArray, int[] userGuessesArray, int[] resultArray)
        {
            List<int> zeros = new List<int>();
            
            for (int i = 0; i < resultArray.Length; i++)
            {
                if(resultArray[i] == 0){
                    zeros.Add(i);
                }
            }
            if (zeros.Count == 1 || zeros.Count == 0)
            {
                return resultArray;
            }
            else if (zeros.Count == 2)
            {
                if(secretArray[zeros[0]] == userGuessesArray[zeros[1]]){
                    resultArray[zeros[0]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
              
                }
                if (secretArray[zeros[1]] == userGuessesArray[zeros[0]])
                {
                    resultArray[zeros[1]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray); 
                }
                return resultArray;
            }
            else if (zeros.Count == 3)
            {
                // check 0 -> 1 AND  0 -> 2
                if (secretArray[zeros[0]] == userGuessesArray[zeros[1]])
                {
                    resultArray[zeros[0]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[0]] == userGuessesArray[zeros[2]])
                {
                    resultArray[zeros[0]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                // check 1 -> 0  AND  1 -> 2
                if (secretArray[zeros[1]] == userGuessesArray[zeros[0]])
                {
                    resultArray[zeros[1]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[1]] == userGuessesArray[zeros[2]])
                {
                    resultArray[zeros[1]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                // check 2 -> 0  AND  2 -> 1
                if (secretArray[zeros[2]] == userGuessesArray[zeros[0]])
                {
                    resultArray[zeros[2]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[2]] == userGuessesArray[zeros[1]])
                {
                    resultArray[zeros[2]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                return resultArray;
                
            }
            else
            {
                // check 0
                if (secretArray[zeros[0]] == userGuessesArray[zeros[1]])
                {
                    resultArray[zeros[0]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[0]] == userGuessesArray[zeros[2]])
                {
                    resultArray[zeros[0]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[0]] == userGuessesArray[zeros[3]])
                {
                    resultArray[zeros[0]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                // check 1
                if (secretArray[zeros[1]] == userGuessesArray[zeros[0]])
                {
                    resultArray[zeros[1]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[1]] == userGuessesArray[zeros[2]])
                {
                    resultArray[zeros[1]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[1]] == userGuessesArray[zeros[3]])
                {
                    resultArray[zeros[1]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                // check 2
                if (secretArray[zeros[2]] == userGuessesArray[zeros[0]])
                {
                    resultArray[zeros[2]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[2]] == userGuessesArray[zeros[1]])
                {
                    resultArray[zeros[2]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[2]] == userGuessesArray[zeros[3]])
                {
                    resultArray[zeros[2]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                // check 3
                if (secretArray[zeros[3]] == userGuessesArray[zeros[0]])
                {
                    resultArray[zeros[3]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[3]] == userGuessesArray[zeros[1]])
                {
                    resultArray[zeros[3]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                if (secretArray[zeros[3]] == userGuessesArray[zeros[2]])
                {
                    resultArray[zeros[3]] = 1;
                    CheckForMatches(secretArray, userGuessesArray, resultArray);
                }
                return resultArray;
            }
        }


    }
}
