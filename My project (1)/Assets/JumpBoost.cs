using UnityEngine;

public class JumpBoostCollectible : MonoBehaviour
{
    [Header("Boost Settings")]
    [Tooltip("How much to multiply the player's jump force by.")]
    public float boostMultiplier = 2f; 
    [Tooltip("How many seconds the boost lasts.")]
    public float boostDuration = 5f;   

    [Header("Effects")]
    public AudioClip collectSound;
    public ScreenFlash screenFlashEffect; 

    

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object hitting us is the Player
        if (other.CompareTag("Player"))
        {
            // Try to grab the Player script from the colliding object
            Player playerScript = other.GetComponent<Player>();

            if (playerScript != null)
            {
                // Tell the player to boost their jump!
                playerScript.ApplyJumpBoost(boostMultiplier, boostDuration);

                // Play the sound effect if you have one
                if (collectSound != null)
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                }
                
                // Trigger your screen flash effect!
                

                // Destroy the collectible so it disappears from the scene
                Destroy(gameObject);
            }
        }
    }
}