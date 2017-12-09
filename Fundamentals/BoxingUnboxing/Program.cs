using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxy = new List<object>();
            boxy.Add(7);
            boxy.Add(28);
            boxy.Add(-1);
            boxy.Add(true);
            boxy.Add("Chair");

            int sum = 0;
            foreach(object thing in boxy){
                if(thing is int){
                    sum += (int)thing;
                }

                System.Console.WriteLine(thing);
                
            }
            System.Console.WriteLine("The sum of the integers is : {0}", sum);
        }
    }
}
