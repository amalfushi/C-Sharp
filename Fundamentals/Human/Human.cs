namespace WizNinSam
{
    public class Human
    {
        public string name { get; set; }
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string name, int health = 100, int strength = 3, int intelligence = 3, int dext = 3)
        {
            this.name = name;
            this.health = health;
            this.strength = strength;
            this.intelligence = intelligence;
            this.dexterity = dexterity;
        }

        public void Attack(object opponent)
        {
            if (opponent is Human)
            {
                Human opp = opponent as Human;
                System.Console.WriteLine("{0} attacked {1} for {2} points of damage!", name, opp.name, (strength*5));
                opp.health -= strength*5;
            }
        }
    }
}