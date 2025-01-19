using UnityEngine;
using System.Collections;

public class CowBubblePrompt : MonoBehaviour
{
    public GameObject bubblePrompt; // Reference to the speech bubble (UI element)
    public float delayBeforeBubble = 3f; // Time delay before the bubble appears
    private bool isPlayerNearby = false; // Flag to check if the player is in range
    private bool bubbleShown = false; // Flag to check if the bubble has already been shown

    void Start()
    {
        // Initially hide the speech bubble
        bubblePrompt.SetActive(false);
        Debug.Log("Bubble is initially hidden.");

        // Start coroutine to show the bubble after a delay
        StartCoroutine(ShowBubbleAfterDelay(delayBeforeBubble));
    }

    void Update()
    {
        // Only allow the player to interact if they are nearby and the bubble has been shown
        if (isPlayerNearby && bubbleShown)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Hide the bubble when E is pressed
                bubblePrompt.SetActive(false);
                Debug.Log("Bubble hidden after pressing E.");

                // Prevent the bubble from showing again
                bubbleShown = false;

                // Optional: You can start dialogue or other interactions here
                StartDialogue();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detect if the player enters the interaction area (trigger collider) of the cow
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player entered range.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Detect if the player leaves the interaction area
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player left range.");
        }
    }

    // Coroutine to show the bubble after the specified delay
    private IEnumerator ShowBubbleAfterDelay(float delay)
    {
        // Wait for the specified time (3 seconds)
        yield return new WaitForSeconds(delay);

        // Make the bubble visible after the delay
        bubblePrompt.SetActive(true);
        bubbleShown = true;
        Debug.Log("Bubble shown after delay.");
    }

    // Optional: Method for starting the dialogue or interaction
    private void StartDialogue()
    {
        // Add logic for starting the dialogue or interaction with the cow
        Debug.Log("Starting interaction with the cow.");
    }
}



