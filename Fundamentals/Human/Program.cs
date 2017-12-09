using System;

namespace WizNinSam
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Huey = new Human("Huey");
            Wizard Lewis  = new Wizard("Lewis");
            Ninja Ryu = new Ninja("Ryu");
            Samurai Jack = new Samurai("Jack");

            Lewis.Fireball(Huey);
            Lewis.Fireball(Jack);
            Lewis.Fireball(Ryu);
            System.Console.WriteLine(Huey.health);

            Huey.Attack(Lewis);
            Ryu.Steal(Jack);
            Ryu.Steal(Huey);
            Ryu.Attack(Lewis);
            Ryu.Get_Away();

            Jack.Death_Blow(Lewis);
            Jack.Meditate();
            Jack.Attack(Ryu);
            Jack.Death_Blow(Ryu);

            System.Console.WriteLine(Huey.health);
            System.Console.WriteLine(Lewis.health);
            System.Console.WriteLine(Ryu.health);
            System.Console.WriteLine(Jack.health);
        }
    }
}
