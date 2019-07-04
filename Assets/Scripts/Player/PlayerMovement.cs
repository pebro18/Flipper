using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;                                 // Setting the speed of the player

    private Rigidbody2D rb2d;                           // Reference to the Rigidbody2D
    private Vector2 moveVelocity;                       // Storing the player's movement

    public bool facingRight;                            // False if it is facing right

    [Header("Limit range")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

	void Start () {
        // References..
        rb2d = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        // Player input to move the character
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);

        // When the player press on a movement key it will check if the character is looking left or right side
        float hor = Input.GetAxis("Horizontal");
        if (hor > 0 && !facingRight)
            Flip();
        else if (hor < 0 && facingRight)
            Flip();

        // Limiting the players movement
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    void Flip()
    {
        // Flipping the player to look at the correct direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("oil"))
        {
            speed = 5f;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        speed = 10f;
    }
}
