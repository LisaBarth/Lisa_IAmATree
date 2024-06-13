using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public float playTime = 5.0f;   // Time in seconds to start playing the audio
    public float stopTime = 15.0f;  // Time in seconds to stop the audio
    public float fadeDuration = 2.0f; // Duration of the fade-in and fade-out
    public AnimationCurve fadeInAnimation;
    public AnimationCurve fadeOutAnimation;

    private AudioSource audioSource;
    private float startTime = 0f;
    private float originalVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
            return;
        }

        originalVolume = audioSource.volume;
        audioSource.volume = 0;
        startTime = Time.time;
    }

    void Update()
    {
        float newVolume = 0f;
        if (Time.time >= startTime + playTime && Time.time <= startTime + stopTime)
        {
            newVolume = fadeInAnimation.Evaluate((Time.time - playTime) / fadeDuration);
            newVolume *= originalVolume;
        }
        else if (Time.time >= startTime + stopTime && Time.time <= startTime + stopTime + fadeDuration)
        {
            newVolume = fadeOutAnimation.Evaluate((Time.time - stopTime) / fadeDuration);
            newVolume *= originalVolume;
        }
        audioSource.volume = newVolume;
    }


}
