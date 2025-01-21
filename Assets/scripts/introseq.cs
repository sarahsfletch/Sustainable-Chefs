using UnityEngine;
using UnityEngine.Video;
using System.Collections; // Required for IEnumerator and coroutines
using UnityEngine.UI; // Required for RawImage


public class introseq : MonoBehaviour
{
    public GameObject studioNamePanel;
    public VideoPlayer gameTitleVideo;

    private CanvasGroup studioNameCanvasGroup;

    public RawImage videoDisplay; // Add this line to your class


    private void Awake()
    {
        // Ensure CanvasGroup is assigned correctly
        studioNameCanvasGroup = studioNamePanel.GetComponentInParent<CanvasGroup>();
    }

    private IEnumerator Start()
    {
        // Start the sequence
        yield return PlaySequence();
    }

    private IEnumerator PlaySequence()
    {
    // Show studio name
    studioNamePanel.SetActive(true);
    yield return FadeTo(studioNameCanvasGroup, 1f, 1f); // Fade in over 1 second
    yield return new WaitForSeconds(3f); // Stay visible for 3 seconds
    yield return FadeTo(studioNameCanvasGroup, 0f, 1f); // Fade out over 1 second
    studioNamePanel.SetActive(false);

    // Check if the gameTitleVideo is assigned
    if (gameTitleVideo == null)
    {
        Debug.LogError("gameTitleVideo is not assigned!");
        yield break; // Exit if it is not assigned
    }

    // Activate the video display
    videoDisplay.gameObject.SetActive(true); // Show the RawImage or appropriate display
    gameTitleVideo.gameObject.SetActive(true); // Ensure the video player GameObject is active

    // Play the game title video
    Debug.Log("Activating game title video.");
    gameTitleVideo.Play();

    // Wait for video to finish
    while (gameTitleVideo.isPlaying)
    {
        yield return null;
    }

    Debug.Log("Game title video finished playing.");
    gameTitleVideo.gameObject.SetActive(false); // Deactivate after playing
    videoDisplay.gameObject.SetActive(false); // Hide the RawImage or appropriate display
    }

    private IEnumerator FadeTo(CanvasGroup canvasGroup, float targetAlpha, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha; // Ensure the final alpha is set
    }
}
