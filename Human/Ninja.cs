namespace WizNinSam
{
    public class Ninja: Human
    {
        public Ninja(string name): base(name, 100, 3, 3, 175)
        {
        }

        public void Steal(Human opponent)
        {
            Attack(opponent);
            health += 10;
            System.Console.WriteLine("{0} stole from {1} dealing {2} damage and healing 10hp", name, opponent.name, strength*5);
        }

        public void Get_Away(){
            health -= 15;
            System.Console.WriteLine("{0} escaped but took 15 damage", name);
        }
    }
}