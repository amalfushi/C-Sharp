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
            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================
            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist fromMtVernon = Artists.Where(x => x.Hometown == "Mount Vernon").First();
            System.Console.WriteLine(fromMtVernon);

            //Who is the youngest artist in our collection of artists?
            int minAge = Artists.Min(a=> a.Age);
            Artist youngest = Artists.Where(a => a.Age == minAge).FirstOrDefault();
            System.Console.WriteLine(youngest);
            
            //Display all artists with 'William' somewhere in their real name
            List<Artist> williams = Artists.Where(a => a.RealName.Contains("William")).ToList();
            foreach (Artist william in williams){
                System.Console.WriteLine(william);
            }

            //Display all groups with names less than 8 characters in length.
            List<Group> lt8 = Groups.Where(g => g.GroupName.Length < 8).ToList();
            foreach (Group g in lt8)
            {
                System.Console.WriteLine(g.GroupName);
            }
            
            //Display the 3 oldest artist from Atlanta
            List<Artist> atlantians = Artists.Where(a => a.Hometown == "Atlanta").OrderByDescending(a=> a.Age).Take(5).ToList();
            foreach (Artist atlantian in atlantians){
                System.Console.WriteLine(atlantian);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<string> notNewYork = Artists
                                    .Join(Groups, artist => artist.GroupId, Group => Group.Id, (artist, Group) => { artist.Group = Group; return artist;})
                                    .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                                    .Select(artist => artist.Group.GroupName)
                                    .Distinct()
                                    .ToList();
            foreach(String group in notNewYork){
                System.Console.WriteLine(group);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            List<Artist> wuTang = Artists.Join(Groups, a => a.GroupId, g => g.Id, (a, g)=>{ a.Group = g; return a;})
                                    .Where(a => a.Group.GroupName == "Wu-Tang Clan").ToList();
            foreach (Artist tang in wuTang)
            {
                System.Console.WriteLine(tang.ArtistName);
            }


        }
    }
}
