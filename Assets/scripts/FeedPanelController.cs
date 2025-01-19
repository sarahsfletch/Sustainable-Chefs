using UnityEngine;
using UnityEngine.UI;

public class FeedPanelController : MonoBehaviour
{
    [Header("UI Elements")]
    public Button grainButton;       // Reference to the Grain button
    public Button grassButton;       // Reference to the Grass button
    public Image feedImage;          // Reference to the image that will change

    [Header("Sprites")]
    public Sprite grainSprite;       // Sprite to display when Grain button is clicked
    public Sprite grassSprite;       // Sprite to display when Grass button is clicked

    void Start()
    {
        // Ensure buttons have listeners to trigger functions when clicked
        grainButton.onClick.AddListener(OnGrainButtonClicked);
        grassButton.onClick.AddListener(OnGrassButtonClicked);
    }

    // Method called when Grain button is clicked
    void OnGrainButtonClicked()
    {
        // Change the image to the grain sprite
        feedImage.sprite = grainSprite;
        Debug.Log("Grain selected");
    }

    // Method called when Grass button is clicked
    void OnGrassButtonClicked()
    {
        // Change the image to the grass sprite
        feedImage.sprite = grassSprite;
        Debug.Log("Grass selected");
    }
}

