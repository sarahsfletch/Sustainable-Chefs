using UnityEngine;
using UnityEngine.UI;

public class BoxInteraction : MonoBehaviour
{
    [Header("GameObject Elements")]
    public SpriteRenderer boxSpriteRenderer; // SpriteRenderer of the box
    public Sprite newBoxSprite; // Sprite to change to on trigger
    public Sprite originalBoxSprite; // Store the original box sprite (set this in the Inspector)
    public GameObject cropPanel; // Reference to the CropPanel UI
     public Image cropPanelImage;
    public Button waterButton; // Button for watering
    public Button fertilizerButton; // Button for fertilizing
    public Button harvestButton; // Button for harvesting
    public GameObject BlueWater; // GameObject for the blue water effect (to be revealed by the mask)
    public GameObject FertWater;

[Header("Sprites for CropPanel")]
    public Sprite waterSprite; // Sprite to display when the Water button is clicked
    public Sprite fertilizerSprite; // Sprite to display when the Fertilizer button is clicked
    public Sprite harvestSprite; // Sprite to display when the Harvest button is clicked


    // [Header("Animations")]
    // public Animator cropAnimator; // Animator for the crop/plant
    // public string waterAnimationTrigger = "Water"; // Trigger name for water animation
    // public string fertilizerAnimationTrigger = "Fertilize"; // Trigger name for fertilizing animation
    // public string harvestAnimationTrigger = "Harvest"; // Trigger name for harvest animation

    [Header("WaterAnimator")]     // Reference to the Water Button
    public Animator SpriteMask;    // Reference to the Animator of the object
    public string triggerName = "PlayWaterAnimation";
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
        //harvestButton.onClick.AddListener(OnHarvestButtonClicked);
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
 // Change the CropPanel sprite to the water sprite
        if (cropPanelImage != null && waterSprite != null)
        {
            cropPanelImage.sprite = waterSprite;
        }
       if (FertWater != null)
        {
            FertWater.SetActive(false);  // Hide the green water effect
        }

        // Enable water mask and show the blue water effect
        if (SpriteMask != null && BlueWater != null)
        {
            SpriteMask.SetTrigger(triggerName);  // Enable the water mask
            BlueWater.SetActive(true);  // Show the blue water effect (revealed by the mask)
        }
        // Trigger the water animation for the crop
        // if (SpriteMask != null)
        // {
        //     SpriteMask.SetTrigger(triggerName); // This will trigger the animation to play
        // }
    }

    private void OnFertilizerButtonClicked()
    {
        Debug.Log("Fertilizer button clicked");
        if (cropPanelImage != null && fertilizerSprite != null)
        {
            cropPanelImage.sprite = fertilizerSprite;
        }
        // Trigger the fertilizing animation for the crop
        if (BlueWater != null)
        {
            BlueWater.SetActive(false);  // Hide the blue water effect
        }

        // Enable fertilizer mask and show the green water effect
        if (SpriteMask != null && FertWater != null)
        {
            SpriteMask.enabled = true;  // Enable the mask (same one used for both)
            FertWater.SetActive(true);
            SpriteMask.SetTrigger(triggerName);  // Show the green water effect (revealed by the mask)
        }

        //  if (SpriteMask != null && FertWater != null)
        // {
        //     SpriteMask.enabled = true;  // Enable the fertilizer mask
        //     FertWater.SetActive(true);  // Reveal and show the FertWater GameObject
        // }
        //  if (SpriteMask != null)
        // {
        //     SpriteMask.SetTrigger(triggerName); // This will trigger the animation to play
        // }
        }
       

    // private void OnHarvestButtonClicked()
    // {
    //     Debug.Log("Harvest button clicked");

    //     if (cropPanelImage != null && harvestSprite != null)
    //     {
    //         cropPanelImage.sprite = harvestSprite;
    //     }

    //     // Trigger the harvest animation for the crop
    //     if (cropAnimator != null)
    //     {
    //         cropAnimator.SetTrigger(harvestAnimationTrigger);
    //     }
    // }
}
