using UnityEngine;
using System.Collections;

public class ChangeIntensity : MonoBehaviour
{
    public float targetIntensity = 0.5f; // Target intensity multiplier
    public float duration = 10.0f; // Duration for the transition
    public float delay = 25.0f; // Delay before starting the transition

    void Start()
    {
        // Start the coroutine to change the ambient intensity gradually after a delay
        StartCoroutine(ChangeAmbientIntensityAfterDelay());
    }

    IEnumerator ChangeAmbientIntensityAfterDelay()
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(delay);

        float initialIntensity = RenderSettings.ambientIntensity;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            RenderSettings.ambientIntensity = Mathf.Lerp(initialIntensity, targetIntensity, elapsedTime / duration);
            yield return null;
        }

        // Ensure the final intensity is set to the target value
        RenderSettings.ambientIntensity = targetIntensity;
    }
}
