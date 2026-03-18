using UnityEngine;
using System.Collections; // Required for Coroutines

public class Spawner : MonoBehaviour
{
    // Assign your collectible prefab(s) in the Unity Inspector
    public GameObject[] collectiblePrefabs; 
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // Define a cubic spawn area
    public float spawnInterval = 5f; // Time in seconds between spawns

    void Start()
    {
        // Start the spawning routine when the game begins
        StartCoroutine(SpawnCollectiblesRoutine()); 
    }

    // Coroutine to spawn items at intervals
    IEnumerator SpawnCollectiblesRoutine()
    {
        while (true) // Infinite loop for continuous spawning
        {
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
            SpawnRandomCollectible();
        }
    }

    void SpawnRandomCollectible()
    {
        // 1. Select a random collectible type from the array
        int randomIndex = Random.Range(0, collectiblePrefabs.Length); // Range is exclusive at max
        GameObject collectibleToSpawn = collectiblePrefabs[randomIndex];

        // 2. Determine a random position within the defined area
        Vector3 randomSpawnPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // 3. Instantiate the selected prefab at the random position with no rotation
        Instantiate(collectibleToSpawn, randomSpawnPosition, Quaternion.identity);
    }

    // Optional: Draw a wire cube in the Scene view to visualize the spawn area
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}