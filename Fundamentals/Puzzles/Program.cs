using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        public static int[] RandomArray(Random rand)
        {
            // Random randy = new Random();
            int[] arr = new int[10];
            int max = arr[0];
            int min = 26;
            int sum = 0;

            for(int i=0; i< 10; i++)
            {
                arr[i]=rand.Next(5, 25);
                if(arr[i] > max)
                {
                    max = arr[i];
                }
                if(arr[i] <  min)
                {
                    min = arr[i];
                }
                sum += arr[i];
            }
            System.Console.WriteLine("Min: {0}, Max: {1}, Sum: {2}", min, max, sum);

            return arr;
        }

        public static string CoinFlip(Random rand){
            // Random rand = new Random();
            System.Console.WriteLine("Tossing a coin");
            int rVal = rand.Next(0,1);
            System.Console.WriteLine(rVal);
            if (rVal == 0){
                System.Console.WriteLine("Heads!");
                return "Heads";
            } else {
                System.Console.WriteLine("Tails!");
                return "Tails";
            }
        }

        public static double TossMultipleCoins(int num, Random rand)
        {
            int cHeads = 0;
            int cTails = 0;

            for (int i=0; i<num; i++)
            {
                // string toss = CoinFlip(new Random());
                if (CoinFlip(rand) == "Heads")
                {
                    cHeads ++;
                }
                else 
                {
                    cTails++;
                }
            }

            return (double)cHeads/cTails;
        }

        public static string[] Names()
        {
            string[] names = new string[5] {"Barry", "Bari", "Boli", "Bully", "Bob"};
            Random rand = new Random();

            for(int i = 0; i< names.Length; i++)
            {
                int randIdx = rand.Next(i, names.Length-1);
                string temp = names[i];
                names[i] = names[randIdx];
                names[randIdx] = temp;
                System.Console.WriteLine(names[i]);
            }

            List<string> nameList = new List<string>();

            foreach(string name in names)
            {
                if(name.Length >= 5)
                {
                    nameList.Add(name);
                }
            }
                return nameList.ToArray();
        }

        static void Main(string[] args)
        {
            Random randy = new Random();
            RandomArray(randy);
            System.Console.WriteLine(TossMultipleCoins(5, randy));
            System.Console.WriteLine("[{0}]", string.Join(", ", Names()));
        }
    }
}
