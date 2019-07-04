using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralScript : MonoBehaviour {

    public float MaxHPCoral = 300f;
    //public float currentCoralHP;
    public float WaitingTime = 10f;
    public float DPO = 5;

	// Use this for initialization
	void Start () {
        GameManager.Instance.KoraalHP = MaxHPCoral;
        //currentCoralHP = MaxHPCoral;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Afval"))
        {
            col.GetComponent<Rigidbody2D>().drag = 50f;
            StartCoroutine(DestroyAftertrigger(col.gameObject));
            Debug.Log(col);
        }
    }
    IEnumerator DestroyAftertrigger(GameObject ColObject)
    {
        yield return new WaitForSeconds(WaitingTime);
        if (ColObject.activeSelf) {
            Destroy(ColObject);
            GameManager.Instance.KoraalHP -= DPO;
        }
    }
}
