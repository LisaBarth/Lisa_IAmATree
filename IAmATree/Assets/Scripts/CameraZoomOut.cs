using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOut : MonoBehaviour
{

    public GameObject xrOrigin;
    public GameObject handVisualizer;
    public GameObject leftHand;
    public GameObject rightHand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(CameraPositionChanger());
        }
    }

    IEnumerator CameraPositionChanger()
    {
        // Disable XR Rig movement
        handVisualizer.SetActive(false);
        leftHand.SetActive(false);
        rightHand.SetActive(false);

        // Define initial and target positions
        float elapsedTime = 0f;
        float duration = 20.0f; // Example duration in seconds
        float distanceUp = 10.0f; // Example distance to move up
        float distanceBack = 20.0f; // Example distance to move back
        
        Vector3 initialPosition = xrOrigin.transform.position;
        Vector3 targetPosition = initialPosition + xrOrigin.transform.up * distanceUp + (-xrOrigin.transform.forward) * distanceBack;

        while (elapsedTime < duration)
        {
            // Calculate the position using Lerp in local space
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);

            // Update the object's position
            xrOrigin.transform.position = newPosition;

            // Increment elapsedTime
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        
    }
}
