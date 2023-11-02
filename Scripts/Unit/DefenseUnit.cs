using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUnit : MonoBehaviour
{
    protected bool touchTower = false;
    public static int MaxHealth{get; set;}
    private int currentUnitHealth;
    public float AtkSpeed { get; set; } // atk speed
    public int Damage { get; set; }
    protected Vector3 movement;

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

    protected void OnCollisionEnter2D(Collision2D collision)
    {

    }

    // move object to right / left relatively to tags (ally, enemy)
    protected virtual void Move()
    {
        // Apply the translation
        transform.Translate(movement);
    }

    // destroy the unit when health reaches 0
    public bool IsDestroyed()
    {
       return currentUnitHealth == 0;
    }
}
