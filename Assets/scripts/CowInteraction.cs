using UnityEngine;

public class CowInteraction : MonoBehaviour
{
    [Header("NPC Settings")]
    public string npcName = "Cow";

    [Header("UI Settings")]
    public GameObject FeedPanel;          // The panel that shows feeding options (popup)
    public GameObject interactionPrompt;  // The prompt that tells the player to press E
    private bool isPlayerNearby = false;

    void Start()
    {
        // Ensure FeedPanel is hidden at the start
        if (FeedPanel != null)
        {
            FeedPanel.SetActive(false); // Hide the FeedPanel initially
        }
    }

    void Update()
    {
        // If player is near and presses 'E', show or hide the FeedPanel
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleFeedPanel();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detect when the player enters the interaction range (trigger zone)
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is near " + npcName);

            // Show the interaction prompt
            if (interactionPrompt != null)
            {
                interactionPrompt.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Detect when the player leaves the interaction range (trigger zone)
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player left " + npcName);

            // Hide the interaction prompt when player leaves
            if (interactionPrompt != null)
            {
                interactionPrompt.SetActive(false);
            }
        }
    }

    void ToggleFeedPanel()
    {
        if (FeedPanel != null)
        {
            // Toggle the FeedPanel's active state (show or hide it)
            bool isActive = FeedPanel.activeSelf;
            FeedPanel.SetActive(!isActive);

            if (!isActive)
                Debug.Log("FeedPanel opened.");
            else
                Debug.Log("FeedPanel closed.");
        }
        else
        {
            Debug.LogWarning("FeedPanel is not assigned!");
        }
    }
}


