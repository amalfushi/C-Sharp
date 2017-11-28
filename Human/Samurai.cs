namespace WizNinSam
{
    public class Samurai: Human
    {
        public Samurai(string name): base(name, 200, 3, 3, 3)
        {
        }

        public void Death_Blow(Human opponent)
        {
            if(opponent.health < 50)
            {
                opponent.health = 0;
                System.Console.WriteLine("{0} had a killing blow on {1} and reduced their hp to 0!", name, opponent.name);
            } else {
                Attack(opponent);
            }
        }

        public void Meditate()
        {
            health = 200;
            System.Console.WriteLine("{0} meditated and restored their health to 200", name);
        }
    }
}