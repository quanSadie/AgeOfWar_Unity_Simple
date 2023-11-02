using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TowerHitPoints : MonoBehaviour
{
    // getting attacked
    private bool beingAttacked = false; // check if the tower is being attacked
    private float attackDelay; // Time delay between attacks in seconds
    private float lastAttackTime;

    // health bar
    private static int maxHealth = 100; // max health
    public int CurrentHealth { get; set; } // current health
    private float healthbarvalue; // max health bar length
    [SerializeField] GameObject healthBar; // remaining health bar 

    [SerializeField] private ParticleSystem collisionEffect; // effect when being attacked

    // attacking unit
    private DefenseUnit unit;
    private int DmgTaken = 0;

    void Start()
    {
        lastAttackTime = 0f;
        healthbarvalue = healthBar.transform.localScale.x;
        CurrentHealth = maxHealth;
        collisionEffect.Pause();
    }

    void Update()
    {
        // set atk time 
        if (beingAttacked && Time.time - lastAttackTime >= attackDelay)
        {
            lastAttackTime = Time.time;
            // take damage based on unit damage
            TakeDamage(DmgTaken);
            UnityEngine.Debug.Log("Remaining health: " + CurrentHealth);
            UnityEngine.Debug.Log("atk delay: " + attackDelay);
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.transform.localScale = new Vector3(healthbarvalue * CurrentHealth / maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Unit") && gameObject.name == "EnemyTower")
        {
            // Check if the colliding unit is destroyed
            unit = collision.gameObject.GetComponent<DefenseUnit>();
            attackDelay = 1 / unit.AtkSpeed; // set atk delay to unit's atk speed
            DmgTaken = unit.Damage;
            if (unit != null && unit.IsDestroyed())
            {
                beingAttacked = false;
                collisionEffect.Pause();
            }
            else
            {
                beingAttacked = true;
                Vector2 collisionPoint = collision.contacts[0].point;

                // Set the particle system position to the collision point
                collisionEffect.transform.position = collisionPoint;

                // Play the particle system
                collisionEffect.Play();
            }
        } else if (collision.gameObject.CompareTag("EnemyUnit") && gameObject.name == "AllyTower")
        {

            // Check if the colliding unit is destroyed
            unit = collision.gameObject.GetComponent<DefenseUnit>();
            attackDelay = 1 / unit.AtkSpeed; // set atk delay to unit's atk speed
            DmgTaken = unit.Damage;
            if (unit != null && unit.IsDestroyed())
            {
                beingAttacked = false;
                collisionEffect.Pause();
            }
            else
            {
                beingAttacked = true;
                Vector2 collisionPoint = collision.contacts[0].point;

                // Set the particle system position to the collision point
                collisionEffect.transform.position = collisionPoint;

                // Play the particle system
                collisionEffect.Play();
            }
        }
    }
}
