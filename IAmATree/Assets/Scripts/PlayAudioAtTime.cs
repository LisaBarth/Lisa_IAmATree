using UnityEngine;

public class PlayAudioAtTime : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource to play the audio clip
    public float startTimeThreshold = 30.0f; // Time (in seconds) when to start playing the audio clip
    public float startTimestamp = 5.0f; // Timestamp (in seconds) to start playing from

    private bool hasStarted = false;

    void Start()
    {
        

        // Ensure the AudioSource is set to play from the specified start timestamp
        audioSource.time = startTimestamp;

        // Check if Time.time has reached the startTimeThreshold
        if (Time.time >= startTimeThreshold && !hasStarted)
        {
            // Play the AudioClip from the AudioSource
            audioSource.Play();
            hasStarted = true;
        }
    }
}
