using System;
using System.Collections.Generic;
using DbConnection;
using System.Text.RegularExpressions;

namespace SimpleCrud
{
    class Program
    {
        // public users;
        static void Main(string[] args)
        {
            Read();
            Create();
        }
        
        public static void Read(){
           List<Dictionary<string, object>> users = DbConnector.Query("SELECT first_name, last_name FROM users");
        //    System.Console.WriteLine(users);
        //    System.Console.WriteLine("got here");
           for(int i=0; i<users.Count; i++)
           {
            //    System.Console.WriteLine(users[i]);
               foreach (String key in users[i].Keys)
               {
                   System.Console.Write($"{key}: {users[i][key]}, ");
                   
               }
               System.Console.WriteLine();
           }
        }

        public static void Create(){
            string first_name = "";
            string last_name = "";
            int fav_num;
            // var regex = new Regex();
            
            System.Console.WriteLine("\nPlease Enter First Name");
            first_name = Console.ReadLine();
            while(first_name.Length<2)
            {
                System.Console.WriteLine("\nFirst Names must be more than 2 characters. Try again!");
                first_name = "";
                first_name = Console.ReadLine();
            }
            // System.Console.WriteLine(first_name);
            System.Console.WriteLine("\nPlease Enter Last Name");
            last_name = Console.ReadLine();
            while(last_name.Length<2)
            {
                System.Console.WriteLine("\nLast Names must be more than 2 characters. Try again!");
                last_name = "";
                last_name = Console.ReadLine();
            }

            System.Console.WriteLine("\nPlease Enter Favorite Number");
            string temp = Console.ReadLine();
            while(!(Int32.TryParse(temp, out fav_num)))
            {
                System.Console.WriteLine("\nNumbers only, dummy");
                temp = Console.ReadLine();
            }
            DbConnector.Execute($"INSERT INTO users (first_name, last_name, favorite_number) VALUES (\"{first_name}\", \"{last_name}\", \"{fav_num}\")");
            Read();
        }
}

    }