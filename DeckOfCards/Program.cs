using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d1 = new Deck();
            // System.Console.WriteLine(d1.ToString());
            d1.Shuffle();
            // System.Console.WriteLine(d1.ToString());
            Player p1 = new Player("Franklin");
            System.Console.WriteLine(p1.Draw(d1));
            System.Console.WriteLine(p1.Draw(d1));
            System.Console.WriteLine(p1.Draw(d1));
            System.Console.WriteLine(p1.Draw(d1));
            System.Console.WriteLine(p1.ToString());

            p1.Discard(2);
            p1.Discard(6);

            System.Console.WriteLine(p1.ToString());
        }
    }
}