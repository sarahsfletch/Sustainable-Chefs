using UnityEngine;
using UnityEngine.UI;

public class BoxInteraction : MonoBehaviour
{
    [Header("GameObject Elements")]
    public SpriteRenderer boxSpriteRenderer; // SpriteRenderer of the box
    public Sprite newBoxSprite; // Sprite to change to on trigger
    public Sprite originalBoxSprite; // Store the original box sprite (set this in the Inspector)
    public GameObject cropPanel; // Reference to the CropPanel UI
    public Button waterButton; // Button for watering
    public Button fertilizerButton; // Button for fertilizing
    public Button harvestButton; // Button for harvesting

    [Header("Animations")]
    public Animator cropAnimator; // Animator for the crop/plant
    public string waterAnimationTrigger = "Water"; // Trigger name for water animation
    public string fertilizerAnimationTrigger = "Fertilize"; // Trigger name for fertilizing animation
    public string harvestAnimationTrigger = "Harvest"; // Trigger name for harvest animation

    private bool isPlayerNearby = false; // Check if the player is in range

    void Start()
    {
        // Ensure CropPanel is hidden initially
        cropPanel.SetActive(false);

        // Ensure the box starts with the original sprite
        if (boxSpriteRenderer != null && originalBoxSprite != null)
        {
            boxSpriteRenderer.sprite = originalBoxSprite;
        }

        // Add listeners to the buttons
        waterButton.onClick.AddListener(OnWaterButtonClicked);
        fertilizerButton.onClick.AddListener(OnFertilizerButtonClicked);
        harvestButton.onClick.AddListener(OnHarvestButtonClicked);
    }

    void Update()
    {
        // Open the CropPanel when the player presses 'E' near the box
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            cropPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger collider
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;

            // Change the box sprite to the new sprite
            if (boxSpriteRenderer != null && newBoxSprite != null)
            {
                boxSpriteRenderer.sprite = newBoxSprite;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the trigger collider
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // Restore the original sprite of the box when the player leaves
            if (boxSpriteRenderer != null && originalBoxSprite != null)
            {
                boxSpriteRenderer.sprite = originalBoxSprite;
            }

            // Hide the CropPanel if open
            cropPanel.SetActive(false);
        }
    }

    private void OnWaterButtonClicked()
    {
        Debug.Log("Water button clicked");

        // Trigger the water animation for the crop
        if (cropAnimator != null)
        {
            cropAnimator.SetTrigger(waterAnimationTrigger);
        }
    }

    private void OnFertilizerButtonClicked()
    {
        Debug.Log("Fertilizer button clicked");

        // Trigger the fertilizing animation for the crop
        if (cropAnimator != null)
        {
            cropAnimator.SetTrigger(fertilizerAnimationTrigger);
        }
    }

    private void OnHarvestButtonClicked()
    {
        Debug.Log("Harvest button clicked");

        // Trigger the harvest animation for the crop
        if (cropAnimator != null)
        {
            cropAnimator.SetTrigger(harvestAnimationTrigger);
        }
    }
}
