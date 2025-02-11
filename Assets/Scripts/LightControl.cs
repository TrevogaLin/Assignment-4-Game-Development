using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour
{
    public Light pointLight; // Assign the point light in the Inspector
    private float originalIntensity; // Store the original light intensity
    private Color originalColor; // Store the original light color

    private Coroutine darkenCoroutine; // To track the active darkening coroutine

    void Start()
    {
        // Save the original light settings
        if (pointLight != null)
        {
            originalIntensity = pointLight.intensity;
            originalColor = pointLight.color;
        }
    }

    // Method to darken the light and change its color
    public void DarkenLight(float targetIntensity = 0.1f, Color targetColor = default, float duration = 4f) // Increased duration to 4f
    {
        if (pointLight != null)
        {
            if (targetColor == default) targetColor = Color.black; // Default to black if no color is provided

            // Stop any ongoing darkening coroutine
            if (darkenCoroutine != null)
            {
                StopCoroutine(darkenCoroutine);
            }

            // Start the new darkening coroutine
            darkenCoroutine = StartCoroutine(LerpLight(pointLight.intensity, targetIntensity, pointLight.color, targetColor, duration));
        }
    }

    // Method to reset the light to its original settings instantly
    public void ResetLight()
    {
        if (pointLight != null)
        {
            // Stop any ongoing darkening coroutine
            if (darkenCoroutine != null)
            {
                StopCoroutine(darkenCoroutine);
            }

            // Reset the light instantly
            pointLight.intensity = originalIntensity;
            pointLight.color = originalColor;
        }
    }

    // Coroutine to smoothly change light intensity and color
    private IEnumerator LerpLight(float startIntensity, float targetIntensity, Color startColor, Color targetColor, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            // Lerp the intensity
            pointLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsed / duration);

            // Lerp the color
            pointLight.color = Color.Lerp(startColor, targetColor, elapsed / duration);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the final values are set
        pointLight.intensity = targetIntensity;
        pointLight.color = targetColor;
    }
}
