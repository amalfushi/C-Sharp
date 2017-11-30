using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            // foreach (Artist artist in Artists){
            //     System.Console.WriteLine(artist.Hometown);
            // }
            // Artists = Artists.Join(Groups, a =>a.ar)
            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================
            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist fromMtVernon = Artists.Where(x => x.Hometown == "Mount Vernon").First();
            // System.Console.WriteLine(fromMtVernon);

            //Who is the youngest artist in our collection of artists?
            int minAge = Artists.Min(a=> a.Age);
            Artist youngest = Artists.Where(a => a.Age == minAge).FirstOrDefault();
            // System.Console.WriteLine(youngest);
            
            //Display all artists with 'William' somewhere in their real name
            List<Artist> williams = Artists.Where(a => a.RealName.Contains("William")).ToList();
            // foreach (Artist william in williams){
            //     System.Console.WriteLine(william);
            // }
            
            //Display the 3 oldest artist from Atlanta
            List<Artist> atlantians = Artists.Where(a => a.Hometown == "Atlanta").OrderByDescending(a=> a.Age).Take(5).ToList();
            // foreach (Artist atlantian in atlantians){
            //     System.Console.WriteLine(atlantian);
            // }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            Artists = Artists.Join(Groups, a => a.GroupId, g => g.Id, (a, g) => {a.GroupId=g.Id; return a;}).ToList();
            Groups = Groups.Join(Artists, g => g.Id, a => a.GroupId, (g, a) => {g.Members.Add(a); return g;}).ToList();
            var fromNewYork = Groups.Where(g => g.Members.Where(a => a.Hometown == "New York"));

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
