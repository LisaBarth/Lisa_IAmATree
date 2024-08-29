using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntoScene : MonoBehaviour
{
    public float delayTime = 15f;       // Delay time in seconds before starting the fade-out effect
    public float fadeOutTime = 10f;     // Time in seconds for the fade-out effect
    public Image image;                // Reference to the Image component
    private Color originalColor;        // Original color of the image

    void Start()
    {
        originalColor = image.color;

        // Check if enough time has passed to start the fade-out effect
    }

    void Update()
    {
        if (Time.time >= delayTime)
        {
            StartCoroutine(DecreaseAlphaOverTime());
        }
    }

    IEnumerator DecreaseAlphaOverTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the current alpha value
            float currentAlpha = Mathf.Lerp(originalColor.a, 0f, elapsedTime / fadeOutTime);

            // Update the image color with the new alpha
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, currentAlpha);

            yield return null;
        }

        // Ensure alpha reaches 0 exactly
        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
