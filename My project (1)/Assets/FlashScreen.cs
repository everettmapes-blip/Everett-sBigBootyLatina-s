using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFlash : MonoBehaviour
{
    [Tooltip("Drag your Canvas in here so the script knows where to spawn the image.")]
    public Canvas targetCanvas; 
    public float flashDuration = 0.1f; 
    public Color flashColor = new Color(1f, 1f, 1f, 1f); 

    private Color clearColor = new Color(1f, 1f, 1f, 0f); 

    public void FlashScreen()
    {
        if (targetCanvas == null)
        {
            Debug.LogWarning("ScreenFlash: No Canvas assigned! Please assign a Canvas in the inspector.");
            return;
        }
        
        StartCoroutine(DoFlash());
    }

    private IEnumerator DoFlash()
    {
        Debug.Log("1. Spawning the Flash Image!"); // Let's make sure this runs
        
        GameObject flashObject = new GameObject("DynamicFlashImage");
        flashObject.transform.SetParent(targetCanvas.transform, false);
        flashObject.transform.SetAsLastSibling(); 
        
        Image flashImage = flashObject.AddComponent<Image>();
        flashImage.color = flashColor;
        flashImage.raycastTarget = false; 

        RectTransform rect = flashObject.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
        
        // Force the scale to 1 just in case Unity tried to shrink it
        rect.localScale = Vector3.one; 

        float timer = 0f;
        while (timer < flashDuration)
        {
            timer += Time.deltaTime;
            float t = timer / flashDuration;
            flashImage.color = Color.Lerp(flashColor, clearColor, t);
            yield return null; 
        }

        Debug.Log("2. Flash finished fading!");
        
        // TEMPORARILY DISABLED so we can inspect the object in the Hierarchy
        // Destroy(flashObject); 
    }
}