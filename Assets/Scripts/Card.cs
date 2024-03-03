using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    // Enum for the Suit of a card, representing the four possible suits.
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    // Enum for the Rank of a card, representing the thirteen possible ranks from Two to Ace.
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    // Properties for Suit and Rank
    public Suit suit;
    public Rank rank;

    // Constructor for the Card class, sets the card's suit and rank upon instantiation.
    public Card(Suit suit, Rank rank)
    {
        this.suit = suit;
        this.rank = rank;
    }
    // Overrides the default ToString() method to provide a meaningful string representation of a Card instance.

    // Formats the string to display the card's rank and suit (ex "Two of Hearts").
    public override string ToString()
    {
        return $"{rank} of {suit}";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
