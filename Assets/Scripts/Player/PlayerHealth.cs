using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;                         // The max health that the player can get
    public int currentHealth;                           // The current health of the player

    public Slider healthSlider;                         // Reference to the player's health bar
    public Image damageImage;                           // Reference to an image that flashes when the player takes damage

    PlayerMovement playerMovement;                      // Reference to the player's movement

    bool isDead;                                        // When this is true the player is dead
    bool damaged;                                       // True when the player takes damage

    public int fishHeal = 10;

    public AudioClip[] hurt;
    public AudioSource hurtSource;
    // public float BPM = 128;

    void Awake()
    {
        // References..
        playerMovement = GetComponent<PlayerMovement>();

        // Setting the starting health from the player
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        //damaged = true;

        // Taking the health from the player by the damage amount
        currentHealth -= amount;

        PlayHurt();

        // Set the health bar to the current health
        healthSlider.value = currentHealth;

        // When the current health is lower than 0 and is not dead the player will die
        if (currentHealth <= 0 && !isDead)
        {
            // Calling the Die function
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Checks if the player collides with a gameobject with the tag Food
        if (col.gameObject.tag == "Food")
        {
            // Checks if the player currentHealth is not higher than 99
            if (currentHealth <= 99)
            {
                Debug.Log("nomnomnom");

                // The player gets healed
                currentHealth += fishHeal;

                // Update the health bar
                healthSlider.value = currentHealth;
            }
        }
    }

    void Die()
    {
        // The player is dead
        isDead = true;

        // The player is not able to move anymore
        playerMovement.enabled = false;
        //Destroy(gameObject);
        GameManager.Instance.Lose();
    }

    void PlayHurt()
    {
        int randClip = Random.Range(0, hurt.Length);
        hurtSource.clip = hurt[randClip];
        hurtSource.Play();
    }


}
