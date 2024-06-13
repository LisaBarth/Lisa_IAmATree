using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public float playTime = 5.0f;   // Time in seconds to start playing the audio
    public float stopTime = 15.0f;  // Time in seconds to stop the audio
    public float fadeDuration = 2.0f; // Duration of the fade-in and fade-out

    private AudioSource audioSource;
    private float timer = 0f;
    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private float targetVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
            return;
        }

        audioSource.volume = 0;
        targetVolume = audioSource.volume;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= playTime && !audioSource.isPlaying)
        {
            StartFadeIn();
        }

        if (timer >= stopTime && audioSource.isPlaying)
        {
            StartFadeOut();
        }

        if (isFadingIn)
        {
            FadeIn();
        }

        if (isFadingOut)
        {
            FadeOut();
        }
    }

    void StartFadeIn()
    {
        isFadingIn = true;
        isFadingOut = false;
        audioSource.Play();
    }

    void StartFadeOut()
    {
        isFadingIn = false;
        isFadingOut = true;
    }

    void FadeIn()
    {
        if (audioSource.volume < targetVolume)
        {
            audioSource.volume += Time.deltaTime / fadeDuration;

            if (audioSource.volume >= targetVolume)
            {
                audioSource.volume = targetVolume;
                isFadingIn = false;
            }
        }
    }

    void FadeOut()
    {
        if (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime / fadeDuration;

            if (audioSource.volume <= 0)
            {
                audioSource.volume = 0;
                audioSource.Stop();
                isFadingOut = false;
            }
        }
    }
}
