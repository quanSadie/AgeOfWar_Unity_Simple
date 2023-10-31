using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarbarianUnit : DefenseUnit
{
    new void Start()
    {
        // Set MaxHealth and AtkSpeed for BarbarianUnit
        MaxHealth = 100; 
        AtkSpeed = 1f;   

        // Call the base class Start method to initialize the currentUnitHealth based on MaxHealth
        base.Start();
    }
}
