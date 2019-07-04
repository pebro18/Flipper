using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;                                 // Speed of the enemy
    public float chasingRange;                          // The range that the enemy will chase the player
    public float chasingSpeed;                          // The speed when the enemy chases the player

    public bool chasePlayer;                            // True when the enemy chases the player

    public Transform player;                            // Reference to the player

    private float waitTime;
    public float startWaitTime;

    public bool facingRight = true;                     // Checking if the player is facing left or right

    [Header("Swim Range")]
    public Transform patrolDest;                        // Reference to the patrolDest
    public float minX;                                  // Minimum of the X
    public float maxX;                                  // Maximum of the X
    public float minY;                                  // Minimum of the Y
    public float maxY;                                  // Maximum of the Y

    void Start()
    {
        // Reference to the Player gameobject
        player = GameObject.FindGameObjectWithTag("Player").transform;

        waitTime = startWaitTime;

        // Setting a new position for the patrolDest
        patrolDest.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        // Checking if the player is in the chasingRange
        if (Vector2.Distance(transform.position, player.position) < chasingRange)
        {
            // The player is chasing the player
            chasePlayer = true;

            // Chasing the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, chasingSpeed * Time.deltaTime);
        }
        else
        {
            // The enemy is not chasing the player
            chasePlayer = false;

            // Moving towards the patrolDest
            transform.position = Vector2.MoveTowards(transform.position, patrolDest.position, speed * Time.deltaTime);

            // Checks if the distance between the enemy and patrolDest is less than .2f
            if (Vector2.Distance(transform.position, patrolDest.position) < .2f)
            {
                if (waitTime <= 0)
                {
                    // Setiing a new position for the patrolDest
                    patrolDest.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void FixedUpdate()
    {
        // Checking if chasePlayer is true
        if (chasePlayer)
        {
            // Checks if the enemy position is less than the players position and is not facing the right side
            if (transform.position.x < player.position.x && !facingRight)
            {
                // Calling the Flip function
                Flip();
            }
            // When the position of the enemy is not less than the players position and is not facing the right side
            // then it will check if the position is bigger than the player's position and is facing the right side
            else if(transform.position.x > player.position.x && facingRight)
            {
                // Calling the Flip function
                Flip();
            }
        }

        // Checking if chasePlayer is false
        if (!chasePlayer)
        {
            // Checks if the enemy position is less than the patrolDest position and is not facing the right side
            if (transform.position.x < patrolDest.position.x && !facingRight)
            {
                // Calling the Flip function
                Flip();
            }
            // When the position of the enemy is not less than the patrolDest position and is not facing the right side
            // then it will check if the position is bigger than the patrolDest's position and is facing the right side
            else if (transform.position.x > patrolDest.position.x && facingRight)
            {
                // Calling the Flip function
                Flip();
            }
        }
    }

    void Flip()
    {
        // Flipping the enemy to the right direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnDrawGizmosSelected()
    {
        // Drawing a sphere around the enemy that is the range of the chasingRange
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingRange);
    }

}
