using UnityEngine;
using System.Collections;

public class DirectionalLightTransition : MonoBehaviour
{
    public Color targetColor = new Color(0.792f, 0.055f, 0.141f); // Target color to transition to (CA0E24)
    public float transitionDuration = 5.0f; // Duration of the transition effect
    public float delayBeforeTransition = 10.0f; // Delay before starting the transition

    private Color originalColor; // Original color of the directional light
    public Light directionalLight; // Reference to the directional light component
    private bool transitioning = false; // Flag to check if transition is ongoing

    void Start()
    {

        // Get the original color of the directional light
        originalColor = directionalLight.color;

        // Start the coroutine to transition the light color after a delay
        StartCoroutine(StartTransitionAfterDelay());
    }

    IEnumerator StartTransitionAfterDelay()
    {
        // Wait for the specified delay before starting the transition
        yield return new WaitForSeconds(delayBeforeTransition);

        // Set the transitioning flag to true
        transitioning = true;

        // Cache the start time of the transition
        float startTime = Time.time;

        // Gradually transition the light color
        while (Time.time - startTime < transitionDuration)
        {
            float t = (Time.time - startTime) / transitionDuration;
            Color lerpedColor = Color.Lerp(originalColor, targetColor, t);
            directionalLight.color = lerpedColor;
            yield return null;
        }

        // Ensure the final color is exactly the target color
        directionalLight.color = targetColor;

        // Reset the transitioning flag
        transitioning = false;
    }

    void OnDisable()
    {
        // Check if still transitioning to avoid resetting during transition
        if (!transitioning)
        {
            // Reset the directional light color to its original color
            directionalLight.color = originalColor;
        }
    }
}
