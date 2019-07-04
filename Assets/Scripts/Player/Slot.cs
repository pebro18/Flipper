using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	private Inventory inventory;
	public int i;

    GameObject pierGO;
    Pier pier;

	void Start(){
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        pierGO = GameObject.FindGameObjectWithTag("Pier");
        pier = pierGO.GetComponent<Pier>();
	}

	void Update()
    {
		if (transform.childCount <= 0) {
			inventory.isFull [i] = false;
		}
	}

	public void DropItem()
    {
        if(pier.atPier == true) {
	    foreach (Transform child in transform) {
            Debug.Log("I just dropped 1 item");
		    GameObject.Destroy(child.gameObject);
            pier.currentScore += pier.addScore;
	        }
        }
	}

}
