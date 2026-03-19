using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFlash : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 0.1f; // The time the flash lasts for
    public Color flashColor = new Color(1f, 1f, 1f, 1f); // Opaque white

    private Color clearColor = new Color(1f, 1f, 1f, 0f); // Transparent white
    
    // Call this public method from other scripts to trigger the flash
    public void FlashScreen()
    {
        StartCoroutine(DoFlash());
    }

    private IEnumerator DoFlash()
    {
        // Set to opaque color immediately
        flashImage.color = flashColor;
        Debug.Log("run");
        // Fade out over the duration
        float timer = 0f;
        while (timer < flashDuration)
        {
            timer += Time.deltaTime;
            float t = timer / flashDuration;
            // Use Color.Lerp to smoothly transition the color's alpha from opaque to clear
            flashImage.color = Color.Lerp(flashColor, clearColor, t);
            yield return null; // Wait for the next frame
        }

        // Ensure it is completely clear at the end
        flashImage.color = clearColor;
    }
}