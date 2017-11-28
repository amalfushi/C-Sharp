using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Huey = new Human("Huey");
            Human Lewis  = new Human("Lewis", 85, 4, 2);

            Lewis.Attack(Huey);
            System.Console.WriteLine(Huey.health);

            Huey.Attack(Lewis);
            System.Console.WriteLine(Lewis.health);
        }
    }

    public class Human
    {
        public string name { get; }
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string moniker, int hp = 100, int stre = 3, int inte = 3, int dext = 3)
        {
            name = moniker;
            health = hp;
            strength = stre;
            intelligence = inte;
            dexterity = dext;
        }

        public void Attack(Object opponent)
        {
            if (opponent is Human)
            {
                Human opp = opponent as Human;
                System.Console.WriteLine("{0} attacked {1} for {2} points of damage!", name, opp.name, (strength*5));
                opp.health -= strength*5;
            }
           
        }

        // public void Attack(Human opponent)
        // {
        //     System.Console.WriteLine("{0} is attacking {1} for {2} points of damage!", name, opponent.name, (strength*5));
        //     opponent.health -= strength*5;
        // }
    }
}
