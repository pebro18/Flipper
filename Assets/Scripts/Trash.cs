using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public int attackDamage = 10;

    GameObject coralGO;
    Coral coral;

    void Awake()
    {
        coralGO = GameObject.FindGameObjectWithTag("Coral");
        coral = coralGO.GetComponent<Coral>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Gravity")
        {
            // Debug.Log("GRAVITY");
            this.GetComponent<Rigidbody2D>().drag = 3f;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == coralGO)
        {
            coral.DamagedCoral(attackDamage);
            Debug.Log("ATTACK CORAL!");
            Destroy(this);
        }
    }

}
