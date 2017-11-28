namespace DeckOfCards
{
    public class Card 
    {
        public int val { get; set; }
        public string suit { get; set; }
        public string stringVal { get; set; }

        public Card(int value, string newSuit)
        {
            val = value;
            suit = newSuit;
            
            switch (value)
            {
                case 1:
                    stringVal = "Ace";
                    break;
                case 11:
                    stringVal = "Jack";
                    break;
                case 12:
                    stringVal = "Queen";
                    break;
                case 13:
                    stringVal = "King";
                    break;
                default:
                    stringVal = val.ToString();
                    break;
            }
        }

        public override string ToString()
        {   
            string newString = stringVal + " of " + suit;
            return newString;
        }
    }
}