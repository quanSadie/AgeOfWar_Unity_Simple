using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUnitSpawner : MonoBehaviour
{
    public GameObject unitPrefab; // units 

    private float clickInterval = 1.5f; // delay between buy clicck
    private static int spawnRequest = 0; // spawn request queueing
    private float previousSpawnTime;
    private float elapsedTime = 0.0f;

    void Start()
    {
        previousSpawnTime = 0f;
    }

    void Update()
    {

        elapsedTime += Time.deltaTime;

        if (spawnRequest > 0 && elapsedTime - previousSpawnTime >= clickInterval)
        {
            SpawnUnit();
        }

    }

    public void SpawnUnit()
    {

        Instantiate(unitPrefab, new Vector2(-7.817f, -3.655f), Quaternion.identity);
        previousSpawnTime = elapsedTime;
        spawnRequest--;

    }

    public void SpawnRequest()
    {
        if (IngameUIManager.gold > 0)
        {
            spawnRequest++;
            IngameUIManager.gold -= 2000;
        } else
        {

        }
    }
}
