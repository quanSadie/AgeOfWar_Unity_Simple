using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DefenseUnitSpawner : Spawner
{

    public override void SpawnUnit()
    {
        spawnX = -7.2f;
        spawnY = -3.78f;
        base.SpawnUnit();
    }

    protected void SpawnRequest(Button btn)
    {
        // taking info to choose which unit has been bought
        for (int i = 0; i < unitPrefabs.Length; i++)
        {
            if (unitPrefabs[i].name.Equals(btn.name) && unitPrefabs[i].tag.Equals("Unit"))
            {
                unit_index = i;
                if (unitPrefabs[i].name.Equals("Barbarian"))
                {
                    unitValue = 1500;
                }
                else if (unitPrefabs[i].name.Equals("Tribal Female"))
                {
                    unitValue = 500;
                }
                else if (unitPrefabs[i].name.Equals("Tribal Male"))
                {
                    unitValue = 500;
                }
            }
        }

        if (IngameUIManager.gold > 0)
        {
            spawnRequest++;
            IngameUIManager.gold -= unitValue;
        }
    }
}
