using System;

namespace WizNinSam
{
    public class Wizard : Human
    {
        private Random rand = new Random();
        public Wizard(string name) : base(name, 50, 3, 25)
        {
        }

        public void Heal()
        {
            health += 10*intelligence;
            System.Console.WriteLine("{0} healed for {1}", name, intelligence*10);
        }

        public void Fireball(Human opponent)
        {
            int damage = rand.Next(20,50);
            opponent.health -= damage;
            System.Console.WriteLine("{0} hit {1} with a fireball for {2} damage", name, opponent.name, damage);
        }

    }
}