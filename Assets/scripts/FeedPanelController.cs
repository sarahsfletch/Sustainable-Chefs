using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FeedPanelController : MonoBehaviour
{
    [Header("UI Elements")]
    public Button grainButton;       // Reference to the Grain button
    public Button grassButton;       // Reference to the Grass button
    public Image feedImage;  
    public GameObject feedPanel; 
    public GameObject methanePanel;       
    public GameObject grassPanel;   // Reference to the image that will change

    [Header("Sprites")]
    public Sprite grainSprite;       // Sprite to display when Grain button is clicked
    public Sprite grassSprite;       // Sprite to display when Grass button is clicked
      public Animator[] cowAnimators;
    public Animator cloudAnimator;
    public GameObject cloudObject; 
    

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

        foreach (Animator cowAnimator in cowAnimators)
         if (cowAnimator != null)
        {
            cowAnimator.SetTrigger("Burp");
        }

         // Make the cloud visible by enabling the GameObject
        if (cloudObject != null)
        {
            cloudObject.SetActive(true); // Activate the cloud GameObject
        }

        // Trigger the cloud fade-in animation
        if (cloudAnimator != null)
        {
            cloudAnimator.SetTrigger("Appear"); // Trigger the fade-in animation
        }

         
         StartCoroutine(CloseFeedPanelAfterDelay(0.5f));
         // Start the coroutine to reset everything after 3 seconds
        StartCoroutine(ResetAfterDelay(5f)); // 3 seconds delay
        StartCoroutine(ShowMethanePanelAfterDelay(0.5f));
        
    }

     // Coroutine to wait before closing the FeedPanel
    private IEnumerator CloseFeedPanelAfterDelay(float delay)
    {
        // Wait for the specified time (0.5 seconds)
        yield return new WaitForSeconds(delay);

        // Hide the FeedPanel after the delay
        if (feedPanel != null)
        {
            feedPanel.SetActive(false); // Deactivate the FeedPanel
        }
    }
     // Coroutine to reset everything after the specified delay
    
     private IEnumerator ShowMethanePanelAfterDelay(float delay)
    {
        // Wait for the specified time (1 second)
        yield return new WaitForSeconds(delay);

        // Make the MethanePanel visible after the delay
        if (methanePanel != null)
        {
            methanePanel.SetActive(true); // Activate the MethanePanel
        }
    }
    
    private IEnumerator ResetAfterDelay(float delay)
    {
        // Wait for the specified time (3 seconds)
        yield return new WaitForSeconds(delay);

        // Reset the cow's animation back to idle
        foreach (Animator cowAnimator in cowAnimators)
         if (cowAnimator != null)
        {
            cowAnimator.SetTrigger("Idle");
        }

        // Deactivate the cloud after 3 seconds
        if (cloudObject != null)
        {
            cloudObject.SetActive(false); // Deactivate the cloud to hide it
        }

         if (methanePanel != null)
        {
            methanePanel.SetActive(false); // Deactivate the methane panel
        }
        if (grassPanel != null)
        {
            grassPanel.SetActive(false); // Deactivate the methane panel
        }
    }
   

      // Method called when Grass button is clicked
    void OnGrassButtonClicked()
    {
        // Change the image to the grass sprite
        feedImage.sprite = grassSprite;
        Debug.Log("Grass selected");

        StartCoroutine(ShowGrassPanelAfterDelay(0.5f));
        StartCoroutine(ResetAfterDelay(5f));
        StartCoroutine(CloseFeedPanelAfterDelay(0.5f));
    }
      private IEnumerator ShowGrassPanelAfterDelay(float delay)
    {
        // Wait for the specified time (1 second)
        yield return new WaitForSeconds(delay);

        // Make the grassPanel visible after the delay
        if (grassPanel != null)
        {
            grassPanel.SetActive(true); // Activate the grassPanel
        }
    }
}


  

