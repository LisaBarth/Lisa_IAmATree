using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

public class SinkTrees : MonoBehaviour
{
    public GameObject parentObject; // The parent object whose children you want to sort
    public GameObject referenceObject; // The reference object to measure distance from
    public float deactivationInterval = 1.0f; // Time in seconds between deactivations
    public AnimationCurve movementCurve; // Animation curve to control the movement
    public float movementDuration = 2.0f; // Duration of the movement in seconds
    public float startDisappearance;

    private List<Transform> sortedChildren;
    private float startTime = 0f;
    private bool started = false;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= startTime + startDisappearance && !started)
        {
            started = true;
            if (parentObject == null || referenceObject == null)
            {
                Debug.LogError("ParentObject or ReferenceObject is not assigned.");
                return;
            }

            // Get all children of the parentObject
            List<Transform> children = new List<Transform>();
            foreach (Transform child in parentObject.transform)
            {
                children.Add(child);
            }

            // Sort the children based on distance to the referenceObject
            sortedChildren = children.OrderBy(child => Vector3.Distance(child.position, referenceObject.transform.position)).ToList();

            // Start the coroutine to move and deactivate the children
            StartCoroutine(MoveAndDeactivateChildren());
        }
    }

    private IEnumerator MoveAndDeactivateChildren()
    {
        // Start deactivating from the furthest to the closest
        for (int i = sortedChildren.Count - 1; i >= 0; i--)
        {
            // Move the object down 50 meters using the animation curve
            yield return StartCoroutine(MoveDown(sortedChildren[i]));

            // Deactivate the object
            sortedChildren[i].gameObject.SetActive(false);

            // Wait for the specified interval before moving to the next object
            yield return new WaitForSeconds(deactivationInterval);
        }
    }

    private IEnumerator MoveDown(Transform obj)
    {
        Vector3 startPosition = obj.position;
        Vector3 endPosition = startPosition - new Vector3(0, 50, 0);
        float elapsedTime = 0;

        while (elapsedTime < movementDuration)
        {
            float t = elapsedTime / movementDuration;
            float curveValue = movementCurve.Evaluate(t);
            obj.position = Vector3.Lerp(startPosition, endPosition, curveValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly the end position
        obj.position = endPosition;
    }
}
