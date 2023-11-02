using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    protected int unit_index;

    protected float clickInterval = 1.5f; // delay between buy clicck
    protected static int spawnRequest = 0; // spawn request queueing
    protected float previousSpawnTime;
    protected float elapsedTime = 0.0f;

    // spawn position
    protected float spawnX;
    protected float spawnY;

    [SerializeField] protected GameObject[] unitPrefabs;
    protected GameObject unit;
    protected int unitValue;

    void Start()
    {
        previousSpawnTime = 0f;
        for (int i = 0; i < unitPrefabs.Length; i++)
        {
            Debug.Log(unitPrefabs[i].name);
        }
    }

    void Update()
    {

        elapsedTime += Time.deltaTime;

        if (spawnRequest > 0 && elapsedTime - previousSpawnTime >= clickInterval)
        {
            SpawnUnit();
        }

    }

    public virtual void SpawnUnit()
    {

        unit = Instantiate(unitPrefabs[unit_index], new Vector2(spawnX, spawnY), Quaternion.identity);
        previousSpawnTime = elapsedTime;
        spawnRequest--;

    }
}
