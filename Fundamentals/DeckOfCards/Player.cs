using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        public string name { get; set; }
        public static List<Card> hand;

        public Player(string name)
        {
            this.name = name;
            resetHand();
        }

        public Card Draw(Deck d1)
        {
            hand.Add(d1.Deal());
            return hand[hand.Count-1];
        }

        public Card Discard(int idx)
        {
            if(idx<0 || idx> hand.Count-1)
            {
                return null;
            } else {
                Card removed = hand[idx];
                hand.RemoveAt(idx);
                return removed;
            }
        }
        
        public void resetHand()
        {
            hand = new List<Card>();
        }

        public override string ToString()
        {
            string newString = "Player: " + name + "\nHand: [";
            foreach(Card card in hand)
            {
                newString += card.ToString() + ", ";
            }
            newString += "]";

            // System.Console.WriteLine("Player: {0}\n[{1}]",name , string.Join(", ", hand));
            return newString;
        }
    }
}