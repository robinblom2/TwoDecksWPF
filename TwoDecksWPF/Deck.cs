using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;                   // You'll need this using directive because ObservableCollection is in this namespace. 

namespace TwoDecksWPF
{
    class Deck : ObservableCollection<Card>             // Your Deck class will extend ObservableCollection. That's a collection class that automatically notifies your WPF app any time its items have changed. You'll bind each ListBox to a Deck object.
    {
        private static Random random = new Random();

        public Deck()
        {
            Reset();
        }

        public Card Deal(int index)
        {
            Card cardToDeal = base[index];                          // The Deal()-method deals a card from a specific index in the Deck. It calls base[index] to get the card.  
            RemoveAt(index);                                        // then RemoveAt(index) to remove it from the collection.
            return cardToDeal;                                      // And lastly it returns the card.
        }

        public void Reset()
        {
            Clear();                                                // The Reset()-method clears the deck. 

            for (int suit = 0; suit <= 3; suit++)                   // Then it uses a nested for-loop to add all 13 cards for each of the four suits, calling the Add()-method to add each card. All the cards then gets displayed in the left ListBox.
            {
                for (int value = 1; value <= 13; value++)
                {
                    Add(new Card((Values)value, (Suits)suit));
                }
            }
        }

        /// <summary>
        /// This method shuffles the cards in the deck
        /// </summary>
        public void Shuffle()
        {
            List<Card> copy = new List<Card>(this);                 // The Shuffle()-method first creates a copy of the collection of Cards using this overloaded List<T> constructor.
            Clear();                                                // And then clears the original collection.

            while (copy.Count > 0)                                  // This while loop then iterates thru all of the cards in the collection. (Until all of the cards in the copy have been transfered to the original collection again). 
            {
                int index = random.Next(copy.Count);                // For every iteration of the loop, it chooses a random number (between 0 and the amount of cards left in the copy)
                Card card = copy[index];                            // Picks the card on the corresponding index.
                copy.RemoveAt(index);                               // Removes that specific card from the copy. 
                Add(card);                                          // And adds the card back to the original collection. 
            }
        }

        /// <summary>
        /// This method sorts the cards in the deck
        /// </summary>
        public void Sort()
        {
            List<Card> sortedCards = new List<Card>(this);          // The Sort()-method creates a copy of the collection.
            sortedCards.Sort(new CardComparerByValue());            // It then sorts that copy using the CardComparerByValue (which implements the IComparer-interface).
            Clear();                                                // It clears the original collection.

            foreach (Card card in sortedCards)                      // The foreach loop then calls the Add()-method for each card in sortedCards.
            {
                Add(card);                                          // And adds the cards back to the original collection. 
            }
        }
    }
}
