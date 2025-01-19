using UnityEngine;

public class GrainButtonHandler : MonoBehaviour
{
    public Animator cowAnimator; // Reference to the cow's Animator
    public Animator cloudAnimator; // Reference to the cloud's Animator

    // Method to handle the Grain button click
    public void OnGrainButtonClicked()
    {
        // Trigger the burping animation on the cow
        if (cowAnimator != null)
        {
            cowAnimator.SetTrigger("Burp");
        }

        // Trigger the appearing animation on the cloud
        if (cloudAnimator != null)
        {
            cloudAnimator.SetTrigger("Appear");
        }
    }
}

