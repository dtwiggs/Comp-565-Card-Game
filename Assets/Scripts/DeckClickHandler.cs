using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckClickHandler : MonoBehaviour
{
    public Deck deckScript; // Reference to the Deck script attached to your GameManager

    // Function to detect mouse clicks
    private void OnMouseDown()
    {
        // Check if there is a reference to the Deck script
        if (deckScript != null)
        {
            // Call the function to draw a card for player one
            deckScript.DrawAndDisplayCardFromPlayerOneDeck();
        }
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
