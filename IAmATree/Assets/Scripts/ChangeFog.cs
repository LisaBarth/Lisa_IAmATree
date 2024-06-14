using UnityEngine;
using System.Collections;

public class FogTransition : MonoBehaviour
{
    public float transitionDuration = 5.0f; // Duration of the transition effect
    public float targetDensity = 0.03f; // Target fog density
    public Color targetColor = new Color(0.349f, 0.357f, 0.122f); // Target fog color (595B1F)
    public float delayBeforeTransition = 10.0f; // Delay before starting the transition

    private float originalDensity; // Original fog density
    private Color originalColor; // Original fog color

    void Start()
    {
        // Get the original fog density and color
        originalDensity = RenderSettings.fogDensity;
        originalColor = RenderSettings.fogColor;

        // Start the coroutine to transition the fog after a delay
        StartCoroutine(StartTransitionAfterDelay());
    }

    IEnumerator StartTransitionAfterDelay()
    {
        // Wait for the specified delay before starting the transition
        yield return new WaitForSeconds(delayBeforeTransition);

        // Cache the start time of the transition
        float startTime = Time.time;

        // Gradually transition the fog density and color
        while (Time.time - startTime < transitionDuration)
        {
            float t = (Time.time - startTime) / transitionDuration;
            float lerpedDensity = Mathf.Lerp(originalDensity, targetDensity, t);
            Color lerpedColor = Color.Lerp(originalColor, targetColor, t);

            RenderSettings.fogDensity = lerpedDensity;
            RenderSettings.fogColor = lerpedColor;

            yield return null;
        }

        // Ensure the final values are exactly the target density and color
        RenderSettings.fogDensity = targetDensity;
        RenderSettings.fogColor = targetColor;
    }
}
