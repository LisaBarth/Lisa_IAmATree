using UnityEngine;
using System.Collections;

public class ChangeSkybox : MonoBehaviour
{
    public Material skyboxMaterial; // Reference to the new skybox material
    public float transitionDuration = 5.0f; // Duration of the transition effect
    public Color targetColor = new Color(0.556f, 0.357f, 0.188f); // Target color to transition to (8E5B30)
    public float delayBeforeTransition = 10.0f; // Delay before starting the transition

    private Color originalColor; // Original color of the current skybox material
    private bool transitioning = false; // Flag to check if transition is ongoing

    void Start()
    {
        // Get the original tint color of the current skybox material
        originalColor = RenderSettings.skybox.GetColor("_Tint");

        // Start the coroutine to transition the skybox material after a delay
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

        // Gradually transition the tint color of the skybox material
        while (Time.time - startTime < transitionDuration)
        {
            float t = (Time.time - startTime) / transitionDuration;
            Color lerpedColor = Color.Lerp(originalColor, targetColor, t);
            RenderSettings.skybox.SetColor("_Tint", lerpedColor);
            yield return null;
        }

        // Ensure the final color is exactly the target color
        RenderSettings.skybox.SetColor("_Tint", targetColor);

        // Change the skybox material to the new material
        RenderSettings.skybox = skyboxMaterial;

        // Reset the transitioning flag
        transitioning = false;
    }

    void OnDisable()
    {
        // Check if still transitioning to avoid resetting during transition
        if (!transitioning)
        {
            // Reset the skybox color to light gray (898989) when exiting play mode or stopping the scene
            RenderSettings.skybox.SetColor("_Tint", new Color(0.537f, 0.537f, 0.537f));
        }
    }
}
