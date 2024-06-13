using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public float fadeDuration = 5.0f; // Duration of the fade effect

    private Renderer[] renderers;
    private bool isFading = false;
    private float fadeStartTime;

    void Start()
    {
        // Get all child renderers
        renderers = GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0)
        {
            Debug.LogError("No renderers found in the children of the object.");
            return;
        }

        // Start the fade process
        StartFading();
    }

    void Update()
    {
        if (isFading)
        {
            float elapsedTime = Time.time - fadeStartTime;
            if (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeDuration);
                foreach (var renderer in renderers)
                {
                    foreach (var material in renderer.materials)
                    {
                        Color color = material.color;
                        color.a = alpha;
                        material.color = color;
                    }
                }
            }
            else
            {
                foreach (var renderer in renderers)
                {
                    foreach (var material in renderer.materials)
                    {
                        Color color = material.color;
                        color.a = 0;
                        material.color = color;
                    }
                    renderer.enabled = false; // Disable the renderer after fade-out
                }
                isFading = false;
            }
        }
    }

    private void StartFading()
    {
        // Ensure materials support transparency
        foreach (var renderer in renderers)
        {
            foreach (var material in renderer.materials)
            {
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            }
        }

        // Start the fade process
        fadeStartTime = Time.time;
        isFading = true;
    }
}
