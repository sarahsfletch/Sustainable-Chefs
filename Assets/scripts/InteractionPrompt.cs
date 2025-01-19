using UnityEngine;
using TMPro;  // Add this if you're using TextMeshPro

public class InteractionPrompt : MonoBehaviour
{
    public TextMeshProUGUI popupText; // Reference to the TextMeshProUGUI component
    public float interactionRadius = 2f; // The radius within which the player can interact with the NPC
    private bool isPlayerInRange = false; // Flag to check if the player is in range

    private void Start()
    {
        // Make the popup text inactive initially
        popupText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check distance between the player and NPC
        if (isPlayerInRange)
        {
            // Display the "Press E to talk" message
            popupText.gameObject.SetActive(true);

            // Listen for the E key press to start the dialogue
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        else
        {
            // Hide the popup when the player is not in range
            popupText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the interaction area (trigger collider)
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player has left the interaction area
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void StartDialogue()
    {
        // Your dialogue system logic here (could be a call to another method)
        Debug.Log("Starting Dialogue with NPC!");

        // Optionally, hide the popup when starting the dialogue
        popupText.gameObject.SetActive(false);
    }
}

