using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
     // Reference to the Audio Source component
    public AudioClip soundEffectClip;
    

    // Example: Play sound when an object collides (ensure objects have colliders/rigidbodies)
    private void OnCollisionEnter(Collision collision)
    {
        // Play the assigned AudioClip once upon collision
        
        AudioSource.PlayClipAtPoint(soundEffectClip, transform.position); 
        
    }
}