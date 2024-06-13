using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fadeImage; // Reference to the Image component
    private float fadeSpeed = 0.25f; // Speed of the fade effect
    private bool isFading = false; // Flag to check if currently fading

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0f, 0f, 0f, 1f); // Start with fully black

        while (fadeImage.color.a > 0)
        {
            float newAlpha = fadeImage.color.a - (fadeSpeed * Time.deltaTime);
            fadeImage.color = new Color(0f, 0f, 0f, newAlpha);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
        isFading = false;
    }
}
