using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonUnit : DefenseUnit
{
    private void Awake()
    {
        // Set MaxHealth and AtkSpeed for Unit
        MaxHealth = 25;
        AtkSpeed = 5f;
        Damage = 5;
    }
    protected new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "AllyTower")
        {
            touchTower = true;
        }
    }

    protected override void Move()
    {
        movement = Vector3.left * Time.deltaTime * 2f; // Move right/left with speed and frame-independent movement
        base.Move();
    }
}
