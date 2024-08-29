using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Speed of rotation

    void Update()
    {
        // Rotate the skybox
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
