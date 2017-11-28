using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        enum Suits { Heart, Diamonds, Spades, Clubs }

        public static List<Card> cards;

        private static Random rng = new Random();
        
        public Deck()
        {
            CreateDeck();
        }

        public void CreateDeck(){
            cards =  new List<Card>();
            foreach(Suits suit in Enum.GetValues(typeof(Suits)))
            {
                for(int i=1; i<14; i++)
                {
                    // System.Console.WriteLine(i);
                    cards.Add(new Card(i, suit.ToString()));
                }
            }
        }

        public void Shuffle()
        {
            int n = cards.Count;
            while (n>1)
            {
                n--;
                int k = rng.Next(n+1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }

        public void Reset()
        {
            CreateDeck();
        }

        public Card Deal()
        {
            Card dealCard = cards[0];
            cards.RemoveAt(0);
            return dealCard;
        }

        public override string ToString()
        {
            string newString = "";
            foreach(Card card in cards)
            {
                newString += (card.ToString() + "\n");
            }
            return newString;
        }
    }
}