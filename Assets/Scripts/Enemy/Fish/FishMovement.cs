using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
	public float speed;

	private float waitTime;
	public float startWaitTime;

    public bool facingRight = false;

    GameObject player;

	[Header("Swim Range")]
	public Transform patrolDest;                        // Reference to the patrolDest
	public float minX;                                  // Minimum of the X
	public float maxX;                                  // Maximum of the X
	public float minY;                                  // Minimum of the Y
	public float maxY;                                  // Maximum of the Y

	// Use this for initialization
	void Start ()
	{
        player = GameObject.FindGameObjectWithTag("Player");
		waitTime = startWaitTime;

		// Setting a new position for the patrolDest
		patrolDest.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
	}
	
	// Update is called once per frame
	void Update ()
	{
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

    void FixedUpdate()
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

    void Flip()
    {
        // Flipping the enemy to the right direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            Destroy(gameObject);
        }
    }
}
