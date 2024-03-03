using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private Deck deck;
    private List<Card> playerOneDeck;
    private List<Card> playerTwoDeck;
    void Start()
    {
        deck = FindObjectOfType<Deck>();
        if (deck != null)
        {
            deck.InitializeDeck();
            deck.PrintDeck("Initial Deck", deck.cards);
            deck.Shuffle();
            deck.PrintDeck("Shuffled Deck", deck.cards);


            // Split the deck between two players
            deck.SplitDeck();
            playerOneDeck = deck.GetPlayerOneDeck(); 
            playerTwoDeck = deck.GetPlayerTwoDeck(); 

            
            // Print each player's deck
            deck.PrintDeck("Player One's Deck", playerOneDeck);
            deck.PrintDeck("Player Two's Deck", playerTwoDeck);

            // Draw a card from each player's deck
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
