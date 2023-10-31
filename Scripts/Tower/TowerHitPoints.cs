using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHitPoints : MonoBehaviour
{
    // getting attacked
    private bool beingAttacked = false; // check if the tower is being attacked
    private float attackDelay = 1f; // Time delay between attacks in seconds
    private float lastAttackTime = 0f;

    // health bar
    private static int maxHealth = 100; // max health
    public int CurrentHealth { get; set; } // current health
    private float healthbarvalue; // max health bar length
    [SerializeField] GameObject healthBar; // remaining health bar 

    [SerializeField] private ParticleSystem collisionEffect; // effect when being attacked

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
            Debug.Log("Taking 10 dmg");
            lastAttackTime = Time.time;
            TakeDamage(10);
            Debug.Log("Remaining health: " + CurrentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.transform.localScale = new Vector3(healthbarvalue * CurrentHealth/maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Unit") && gameObject.name == "EnemyTower")
        {
            // Check if the colliding unit is destroyed
            DefenseUnit unit = collision.gameObject.GetComponent<DefenseUnit>();
            attackDelay = unit.AtkSpeed; // set atk delay to unit's atk speed
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
