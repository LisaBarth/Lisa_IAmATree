using UnityEngine;
using System.Collections;

public class ActivateChildren : MonoBehaviour
{
    public float initialDelay = 5.0f; // Delay before starting to activate children
    public float delay = 0.5f; // Time delay between each activation

    private AudioSource audioSource; // Reference to AudioSource component

    void Start()
    {
        // Get the AudioSource component from this GameObject
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(StartActivationAfterDelay());
    }

    IEnumerator StartActivationAfterDelay()
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(initialDelay);

        // Start the coroutine to activate children one by one
        StartCoroutine(ActivateChildrenCoroutine());
    }

    IEnumerator ActivateChildrenCoroutine()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

            // Check if AudioSource is assigned and play sound
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
