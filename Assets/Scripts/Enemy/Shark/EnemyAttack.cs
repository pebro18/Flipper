using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;                                  // Reference to the player
    PlayerHealth playerHealth;                          // Reference to the PlayerHealth script

    [Header("General")]
    public float timeBetweenAttacks = 0.5f;             // Cooldown on the enemy attacks
    public int attackDamage = 10;                       // Amount of damage

	bool playerInRange;                                 // True when the player is in range of the enemy
	float attackTimer;                                  // Counts down for timeBetweenAttack

    [Header("Pufferfish")]
    public bool usingDot = false;

    public float dotAmount;
    float dotTimer;
    

    void Awake()
    {
        // Setting up references
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Checking if the enemy collided with the player
		if(col.gameObject == player)
        {
            Debug.Log("Attack");

            // Setting the boolean to true
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Checking if the enemy exited the player
		if(col.gameObject == player)
        {
            Debug.Log("Left player");

            // Setting the boolean to false
            playerInRange = false;
        }
    }

    void Update()
    {
        // Counting down the timer
        attackTimer += Time.deltaTime;

        if (usingDot && playerInRange)
        {
            DamageOverTime();
        }
        // Checking if the timer is bigger than the timeBetweenAttacks and the enemy is in the playerInRange
        else if(attackTimer >= timeBetweenAttacks && playerInRange)
        {
            // Calling the Attack function
            Attack();
        }

        // Checking if the health of the player is less than 0
        if(playerHealth.currentHealth <= 0)
        {
            //Player dead
        }
    }

    void Attack()
    {
        // Resetting the timer
        attackTimer = 0f;

        // Checking if the health is bigger than 0
        if(playerHealth.currentHealth > 0)
        {
            // Damage the player
            playerHealth.TakeDamage(attackDamage);

			Debug.Log ("You took: " + attackDamage + " damage");
        }
    }

    void DamageOverTime()
    {
        //playerHealth.TakeDamage(dotAmount * Time.deltaTime);
        dotTimer -= Time.deltaTime;

        if(dotTimer <= 0)
        {
            playerHealth.TakeDamage(1);
            dotTimer = 2;
        }
    }


}
