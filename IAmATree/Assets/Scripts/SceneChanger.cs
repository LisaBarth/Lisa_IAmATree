using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Image fadeImage; // Reference to the Image component
    private float fadeSpeed = 0.25f; // Speed of the fade effect
    private bool isFading = false; // Flag to check if currently fading

    public float changeSceneDelay = 10.0f; // Time in seconds before the scene changes automatically
    public string sceneName = "VRScene3"; // Name of the scene to switch to

    void Start()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 0f); // Start with fully transparent
        StartCoroutine(AutoChangeSceneAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        // Temp key controls for manual scene switch and fade-out
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(FadeOut());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Switch scene
            SceneSwitcher();
        }
    }

    void SceneSwitcher()
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeOut()
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0f, 0f, 0f, 0f); // Start with fully transparent

        while (fadeImage.color.a < 1)
        {
            float newAlpha = fadeImage.color.a + (fadeSpeed * Time.deltaTime);
            fadeImage.color = new Color(0f, 0f, 0f, newAlpha);
            yield return null;
        }

        SceneSwitcher(); // Change scene after fade-out
        isFading = false;
    }

    IEnumerator AutoChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(changeSceneDelay);
        StartCoroutine(FadeOut());
    }
}
