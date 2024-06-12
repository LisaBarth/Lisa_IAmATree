using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChanger : MonoBehaviour
{
    /*

    LIST OF GAMEOBJECTS IN THE SCENE

    */

    // LIST OF UNCHANGED OBJECTS
    // Define a list of GameObjects
    public List<GameObject> unChangedGameObjects;

    // LIST OF CHANGED OBJECTS
    // Define a list of GameObjects
    public List<GameObject> changedGameObjects;

    void Update()
    {
        // Toggle change with the space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Get the objects
            GameObject object1 = unChangedGameObjects[0];
            GameObject object2 = changedGameObjects[0];

            // Swap the objects
            Change(object1, object2);

            // Remove object from the unchanged objects
            unChangedGameObjects.RemoveAt(0);

            // Remove object from the changed objects
            changedGameObjects.RemoveAt(0);
        }
    }

    void Change(GameObject first, GameObject second)
    {
        // Change script that will work for all objects
        // Input two objects
        // The first object will disappear from the scene
        // The second object will appear in the scene

        // Disable first
        first.SetActive(false);

        // Enable second
        second.SetActive(true);

    }
}
