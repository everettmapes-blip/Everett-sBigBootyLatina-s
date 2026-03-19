using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collect;
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the collectible has the "Player" tag
        
            // Call a method on the Player script to add to the score or inventory here
            
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