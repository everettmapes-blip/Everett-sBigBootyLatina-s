using UnityEngine;

public class Flash : MonoBehaviour
{
    public GameObject collect;
    public ScreenFlash screenFlashEffect;
    public AudioClip soundEffectClip;

    private void Start()
    {
        // If the slot is empty, search the scene for the ScreenFlash script automatically!
        if (screenFlashEffect == null)
        {
            screenFlashEffect = FindObjectOfType<ScreenFlash>();
            
            if (screenFlashEffect == null)
            {
                Debug.LogWarning("Flash Collectible couldn't find a ScreenFlash script in the scene!");
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
            if (soundEffectClip != null)
            {
                AudioSource.PlayClipAtPoint(soundEffectClip, transform.position);
            }
            
            // Now this will always work because Start() found it for us!
            if (screenFlashEffect != null)
            {
                screenFlashEffect.FlashScreen();
            }
            else
            {
                Debug.LogError("Hey! The Screen Flash Effect slot is empty on " + gameObject.name);
            }

            if (collect != null)
            {
                Destroy(collect);
            }
            else
            {
                Destroy(gameObject); 
            }
        
    }
}