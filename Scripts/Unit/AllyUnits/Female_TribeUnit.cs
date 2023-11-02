using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Female_TribeUnit : DefenseUnit
{
    private void Awake()
    {
        // Set MaxHealth and AtkSpeed for BarbarianUnit
        MaxHealth = 20;
        AtkSpeed = 0.5f;
        Damage = 5;
    }
    protected new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EnemyTower")
        {
            touchTower = true;
        }
    }

    protected override void Move()
    {
        movement = Vector3.right * Time.deltaTime * 2f; // Move right/left with speed and frame-independent movement
        base.Move();
    }
}