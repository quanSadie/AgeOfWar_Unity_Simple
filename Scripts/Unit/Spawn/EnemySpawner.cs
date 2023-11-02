using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    protected float previousSpawnTime;
    protected int unit_index = 0;
    protected float spawnInterval = 5.0f; // Spawn interval set to 5 seconds
    protected float elapsedTime = 0.0f;

    // spawn position
    protected float spawnX;
    protected float spawnY;

    [SerializeField] protected GameObject[] unitPrefabs;
    protected GameObject unit;

    void Start()
    {
        spawnX = 7.93f;
        spawnY = -3.78f;
        previousSpawnTime = 0f;
        for (int i = 0; i < unitPrefabs.Length; i++)
        {
            Debug.Log(unitPrefabs[i].name);
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            SpawnUnit();
            elapsedTime = 0.0f; // Reset the timer after spawning a unit
        }

        // ... rest of your Update logic ...
    }

    public void SpawnUnit()
    {
        unit = Instantiate(unitPrefabs[unit_index], new Vector2(spawnX, spawnY), Quaternion.identity);
        // You can perform additional setup for the spawned unit here if needed
    }
}
