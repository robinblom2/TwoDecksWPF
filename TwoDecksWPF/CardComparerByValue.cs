using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TwoDecksWPF
{
    class CardComparerByValue : IComparer<Card>         // Here's the "guts" of the card sorting, which uses the built-in List.Sort method. Sort takes an IComparer object, which has one method: Compare. This implementation takes two cards at a time and first compares their values, then their suits. 
    {
        public int Compare(Card x, Card y)              // This method gets executed when we call on the Sort()-method. 
        {
            if (x.Suit < y.Suit)                        // We first compare the Suit-values. The most high-valued suits will end up at the bottom of the sorted list. 
            {
                return -1;
            }
            if (x.Suit > y.Suit)
            {
                return 1;
            }
            if (x.Value < y.Value)                      // These statements only get executed if x and y have the same Suit - that means the first two return statements weren't executed. 
            {
                return -1;
            }
            if (x.Value > y.Value)
            {
                return 1;
            }
            return 0;                                   // If none of the other four return statements were hit, the cards must be the same card - so return zero.  
        }
    }
}
