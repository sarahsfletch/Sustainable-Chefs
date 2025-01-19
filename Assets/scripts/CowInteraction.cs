using UnityEngine;

public class CowInteraction : MonoBehaviour
{
    [Header("NPC Settings")]
    public string npcName = "NPC";
    [TextArea] public string[] dialogueLines; // Dialogue lines for the NPC

    private bool isPlayerNearby = false;

    void Update()
    {
        // Check for player interaction
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detect if the player enters the NPC's range
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is near " + npcName);
            // Optional: Show a UI prompt like "Press E to talk"
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Detect if the player leaves the NPC's range
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player left " + npcName);
            // Optional: Hide the UI prompt
        }
    }

    void StartDialogue()
    {
        Debug.Log("Starting dialogue with " + npcName);

        foreach (string line in dialogueLines)
        {
            Debug.Log(line);
        }

        // Optional: Call a UI dialogue manager to display the lines
        // DialogueManager.Instance.StartDialogue(dialogueLines);
    }
}

