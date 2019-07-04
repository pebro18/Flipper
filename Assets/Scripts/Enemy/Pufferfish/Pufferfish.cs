using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : MonoBehaviour
{
	public float blowUpRange;
	public bool blowedUp;
	public float delayDeflate;

	bool playerInRange;
	float timer;
    public SpriteRenderer spriteRenderer;
    public Sprite[] PufferfishSprite;
	public Transform player;

	GameObject playerGO;
	PlayerHealth playerHealth;

	void Awake () {
		playerGO = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = playerGO.GetComponent<PlayerHealth> ();
	}
		
	void Update () {
		if (Vector2.Distance(transform.position, player.position) < blowUpRange)
		{
            spriteRenderer.sprite = PufferfishSprite[0];
			blowedUp = true;
		}
		if(blowedUp == true)
		{
			StartCoroutine(Deflate());
		}
	}

	IEnumerator Deflate()
	{
		yield return new WaitForSeconds(delayDeflate);
        spriteRenderer.sprite = PufferfishSprite[1];
		blowedUp = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject == playerGO)
		{
			Debug.Log("Attack");
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject == playerGO)
		{
			Debug.Log ("Left Player");
		}
	}


	void Attack(){

	}

    

}
