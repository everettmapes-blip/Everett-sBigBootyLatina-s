using UnityEngine;

public class Flash : MonoBehaviour
{
    // Optional: You can add an effect like a sound or visual effect here
    // public AudioClip collectSound; 
    public GameObject collect;
    public ScreenFlash screenFlashEffect;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the collectible has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Call a method on the Player script to add to the score or inventory
        if (screenFlashEffect != null)
        {
            
            screenFlashEffect.FlashScreen();
        }
            
            // Optional: Play a sound effect if you have one
            // AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Destroy the collectible game object after it's collected
            Destroy(collect);

        }
    }
}