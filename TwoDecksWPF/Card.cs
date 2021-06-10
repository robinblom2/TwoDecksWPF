using System;
using System.Collections.Generic;
using System.Text;

namespace TwoDecksWPF
{
    class Card
    {
        public Suits Suit { get; private set; }         // This property is of type Suits. It gets and sets the values from the Suits-enum. 
        public Values Value { get; private set; }       // This property is of type Value. It gets and sets the values from the Value-enum.

        public override string ToString()               // Our Card-object already has a Name property that returns the name of the card. That's exactly what the ToString()-method should do. We add this method to make the code easier to debug. 
        {
            return Name;
        }



        public string Name                              // The Name-property returns the string with the cardname. (The Name property's get accessor takes advantage of the way an enum's ToString method returns its name converted to a string.)
        {
            get
            {
                return $"{Value} of {Suit}";
            }
        }

        public Card(Values value, Suits suit)           // The constructor takes two parameters. A random value, and a random suit. (For example value = 10, suit = 2) The constructor gets those numbers from the RandomCard()-method, when we create a random card.
        {
            this.Suit = suit;
            this.Value = value;
        }
    }
}
