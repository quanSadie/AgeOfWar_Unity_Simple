using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUnit : MonoBehaviour
{
    private bool touchTower = false;
    public static int MaxHealth{get; set;}
    private int currentUnitHealth;
    public float AtkSpeed { get; set; }

    protected void Start()
    {
        currentUnitHealth = MaxHealth;    
    }

    protected void Update()
    {
        // keep moving while not reach enemy tower
        if (!touchTower)
        {
            Move();
        } 
        if (IsDestroyed())
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EnemyTower")
        {
            touchTower = true;
        }

    }

    // move object to right / left relatively to tags (ally, enemy)
    protected void Move()
    {
        // Define the direction of the movement
        Vector3 movement = Vector3.right * Time.deltaTime * 2f; // Move right with speed and frame-independent movement

        // Apply the translation
        transform.Translate(movement);
    }

    // destroy the unit when health reaches 0
    public bool IsDestroyed()
    {
       return currentUnitHealth == 0;
    }
}
