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

    void Start()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 0f); // Start with fully transparent
    }

    // Update is called once per frame
    void Update()
    {
        // temp key controls

        if(Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FadeOut());
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(FadeOut());
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            // Switch scene
            SceneSwitcher();
        }
    }

    void SceneSwitcher()
    {
        SceneManager.LoadScene("VRScene3");
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

        isFading = false;

    }
}
