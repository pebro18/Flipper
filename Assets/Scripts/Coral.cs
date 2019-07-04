using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Coral : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Slider coralHealthSlider;

    bool isDead;

	void Awake ()
    {
        currentHealth = maxHealth;
	}
	
	void Update ()
    {
		
	}

    public void DamagedCoral(int amount)
    {
        currentHealth -= amount;

        coralHealthSlider.value = currentHealth;

        // Damaged Sound

        if(currentHealth <= 0 && !isDead)
        {
            Dead();
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Afval")
        {

        }
    }

    public void Dead()
    {
        isDead = true;

        Debug.Log("Game Over");
    }
}
