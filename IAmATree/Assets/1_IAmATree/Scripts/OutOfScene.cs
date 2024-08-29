using UnityEngine;
using UnityEngine.UI;

public class OutOfScene : MonoBehaviour
{
    public Image imageToDarken; // Reference to the Image component you want to darken
    public float darkenDuration = 10f; // Duration of the darkening effect in seconds
    public float delayBeforeDarken = 20f; // Delay before starting the darkening effect in seconds

    private float currentDelayTime = 0f; // Current elapsed time for the delay
    private bool isDelayOver = false; // Flag to check if delay is over
    private float currentDarkenTime = 0f; // Current elapsed time for the darkening effect

    void Update()
    {
        if (!isDelayOver)
        {
            // Increment the currentDelayTime by deltaTime each frame
            currentDelayTime += Time.deltaTime;

            // Check if delay duration has been reached
            if (currentDelayTime >= delayBeforeDarken)
            {
                isDelayOver = true;
                // Reset currentDelayTime for accuracy in darkening duration
                currentDarkenTime = 0f;
                // Initialize alpha to 0 (fully transparent) at the start of the darkening effect
                imageToDarken.color = new Color(imageToDarken.color.r, imageToDarken.color.g, imageToDarken.color.b, 0f);
            }
        }
        else
        {
            // Increment the currentDarkenTime by deltaTime each frame
            currentDarkenTime += Time.deltaTime;

            // Calculate the new alpha value based on currentDarkenTime
            float alpha = Mathf.Lerp(0f, 1f, currentDarkenTime / darkenDuration);

            // Update the image's alpha
            imageToDarken.color = new Color(imageToDarken.color.r, imageToDarken.color.g, imageToDarken.color.b, alpha);

            // Check if the darken duration has been reached
            if (currentDarkenTime >= darkenDuration)
            {
                // Optionally, you can disable the script or gameObject once the darken effect is complete
                enabled = false; // Disable this script
                //gameObject.SetActive(false); // Disable the entire gameObject
            }
        }
    }
}
