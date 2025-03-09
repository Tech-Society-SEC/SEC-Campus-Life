using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject trashPrefab;   // Assign the TrashItem prefab in Inspector
    public Transform player;         // Assign the Player GameObject in Inspector
    public int trashCount = 10;      // Number of trash items to spawn
    public float spawnRadius = 5f;   // Trash will spawn within this radius of the player
    public float spawnHeightOffset = 0.5f;  // Adjust if trash still spawns inside the ground

    void Start()
    {
        SpawnTrash();
    }

    void SpawnTrash()
    {
        for (int i = 0; i < trashCount; i++)
        {
            Vector3 spawnPosition = GetSpawnPositionNearPlayer();
            Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetSpawnPositionNearPlayer()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned in TrashSpawner!");
            return Vector3.zero;
        }

        // Generate random position within a small radius near the player
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(player.position.x + randomOffset.x, 
                                            player.position.y + spawnHeightOffset,  // Ensures trash spawns above ground
                                            player.position.z + randomOffset.y);

        return spawnPosition;
    }
}
