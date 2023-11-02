using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarbarianUnit : DefenseUnit
{
    private void Awake()
    {
        MaxHealth = 40;
        AtkSpeed = 1f;
        Damage = 10;
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
