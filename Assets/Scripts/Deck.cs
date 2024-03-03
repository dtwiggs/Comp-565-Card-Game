using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Deck : MonoBehaviour
{
    // Array to hold prefabs for each card type.
    public GameObject[] cardPrefabs;

    // The point in the scene where cards will be spawned.
    public Transform spawnPoint;

    // A list representing the full deck of cards.
    public List<Card> cards;

    // Decks for each player.
    private List<Card> playerOneDeck;
    private List<Card> playerTwoDeck;
    void Start()
    {
       
    }
    // Returns the deck of player one.
    public List<Card> GetPlayerOneDeck()
    {
        return playerOneDeck;
    }
    // Returns the deck of player two.
    public List<Card> GetPlayerTwoDeck()
    {
        return playerTwoDeck;
    }
    // Draws and displays the top card from player one's deck.
    public void DrawAndDisplayCardFromPlayerOneDeck()
    {
        // Check if there are cards left in the deck.
        if (playerOneDeck.Count > 0)
        {
            // Draw the top card.
            Card drawnCard = playerOneDeck[0];
            playerOneDeck.RemoveAt(0); // Remove it from the deck

            // Find the corresponding prefab index for the drawn card.
            int prefabIndex = ConvertCardToIndex(drawnCard);

            // Instantiate the card prefab at the spawn point if index is valid.
            if (prefabIndex >= 0 && prefabIndex < cardPrefabs.Length)
            {
                Instantiate(cardPrefabs[prefabIndex], spawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Card prefab index out of range: " + prefabIndex);
            }
        }
        else
        {
            Debug.Log("Player One's deck is empty.");
        }
    }
    // Converts a card object to an index for the cardPrefabs array.
    private int ConvertCardToIndex(Card card)
    {
        // Calculation based on card suit and rank.
        int index = ((int)card.suit) * 13 + ((int)card.rank) - 2; 
        return index;
    }

    
    // Initializes the deck with one of each type of card.
    public void InitializeDeck()
    {
        cards = new List<Card>();// Instantiate the list of cards.
        foreach (Card.Suit suit in System.Enum.GetValues(typeof(Card.Suit))) // Loop through all suits.
        {
            foreach (Card.Rank rank in System.Enum.GetValues(typeof(Card.Rank))) // Loop through all ranks.
            {
                cards.Add(new Card(suit, rank));// Add a new card of each suit and rank to the deck.
            }
        }
    }
    // Splits the deck into two, alternating cards between two players.
    public void SplitDeck()
    {
        playerOneDeck = new List<Card>();// Initialize player one's deck list.
        playerTwoDeck = new List<Card>();// Initialize player two's deck list.

        for (int i = 0; i < cards.Count; i++)// Distribute cards between the two players.
        {
            if (i % 2 == 0)// Even index numbers go to player one.
            {
                playerOneDeck.Add(cards[i]);
            }
            else// Odd index numbers go to player two.
            {
                playerTwoDeck.Add(cards[i]);
            }
        }
        Debug.Log($"Player One Deck Count: {playerOneDeck.Count}"); // Should print 26 after split
        Debug.Log($"Player Two Deck Count: {playerTwoDeck.Count}"); // Should also print 26 after split
    }
    // Shuffles the full deck.
    public void Shuffle()
    {
        System.Random random = new System.Random();// Random number generator.
        int n = cards.Count;
        while (n > 1)// Go through the deck backwards.
        {
            n--;
            int k = random.Next(n + 1);// Pick a random index.
            Card temp = cards[k];// Swap the cards.
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }

    
    
    //  will print the contents of a deck to the console
   public void PrintDeck(string title, List<Card> deck)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(title + ": ");// Append the title of the deck.

        foreach (Card card in deck)// Iterate through each card in the deck.
        {
            // Append each card's details to the string builder.
            sb.Append(card.rank + " of " + card.suit + ", ");
        }

        // Remove the last comma and space 
        if (deck.Count > 0)
        {
            sb.Length -= 2; // Removes the last two characters (", ")
        }

        Debug.Log(sb.ToString()); // Output the string to the Unity console.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
