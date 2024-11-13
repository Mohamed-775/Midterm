using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab; // The collectible prefab to spawn
    public float spawnInterval = 3f;     // How often to spawn collectibles
    public float spawnAreaSize = 10f;    // Size of the area in which collectibles spawn
    public int maxCollectibles = 30;      // Max number of collectibles allowed at once

    private List<GameObject> activeCollectibles = new List<GameObject>();

    private void Start()
    {
        // Start spawning collectibles at regular intervals
        InvokeRepeating("SpawnCollectible", 1.5f, spawnInterval);
    }

    // Spawns a collectible in a random position
    private void SpawnCollectible()
    {
        // Debugging the active collectibles count
        Debug.Log("Active Collectibles: " + activeCollectibles.Count);

        if (activeCollectibles.Count < maxCollectibles)
        {
            // Set spawn Y to an appropriate height (e.g., 1 to make them above the ground)
            float spawnHeight = -0.8f; // Adjust this value as needed for your game

            // Randomize the spawn position for X and Z, but keep Y constant at spawnHeight
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnAreaSize, spawnAreaSize),  // Random X position
                spawnHeight,                                 // Fixed Y position
                Random.Range(-spawnAreaSize, spawnAreaSize)   // Random Z position
            );

            // Instantiate the collectible and add it to the list of active collectibles
            GameObject newCollectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
            activeCollectibles.Add(newCollectible);
        }
    }

    // This method can be called to remove a collectible when it's collected
    public void RemoveCollectible(GameObject collectible)
    {
        if (activeCollectibles.Contains(collectible))
        {
            activeCollectibles.Remove(collectible);
            Destroy(collectible);
        }
    }
}
