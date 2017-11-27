using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Three Basic Arrays
            int[] nums = {1,2,3,4,5,6,7,8,9};
            // Console.WriteLine(nums);

            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            // Console.WriteLine(names);

            bool[] bools = new bool[10];
            for(int i=0; i<=9; i++){
                if ((i+1)%2==0){
                    bools[i] = true;
                } else {
                    bools[i] = false;
                }
            }
            // Console.WriteLine(bools);
            // for(int i=0; i<10; i++){
            //     System.Console.WriteLine(bools[i]);
            // }



            //Multiplication Table
            int[,] multTable = new int[10, 10];
            for(int i=1; i<10; i++){
                for(int j=0; j<10; j++){
                    if(i==0){
                        multTable[0,j] = j;
                        continue;
                    } else if (i>0 && j == 0){
                        multTable[i,0]=i;
                        continue;
                    } else {
                        multTable[i,j] = i*j;
                    }
                }
            }
                
            System.Console.WriteLine(multTable[3,3]);



            //List of Flavors
            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Caramel");
            flavors.Add("Mint");

            System.Console.WriteLine(flavors.Count);
            System.Console.WriteLine(flavors[3]);
            flavors.RemoveAt(3);
            System.Console.WriteLine(flavors[3]);
            System.Console.WriteLine(flavors.Count);






            //User info Dictionary
            Random rand = new Random();
            Dictionary<string, string> users = new Dictionary<string, string>();
            foreach(string name in names){
                users.Add(name, flavors[rand.Next(flavors.Count)]);
            }
            
            
            // foreach(var user in users.Keys){
            //     users[user] = "taco";
            // }

            foreach(KeyValuePair<string, string> entry in users){
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
