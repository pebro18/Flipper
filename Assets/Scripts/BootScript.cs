using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BootScript : MonoBehaviour {
    
    public GameObject Boot;
    public GameObject Afval;
    public float TijdvoornieuwAfval;
    public float power = 3f;
    public Sprite[] PlasticSkins;

	// Use this for initialization
	void Start () {
        StartCoroutine(GooiAfval());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    IEnumerator GooiAfval()
    {
        yield return new WaitForSeconds(TijdvoornieuwAfval);
        GameObject clone;
        Vector2 Boat = Boot.transform.position;
        Boat.y += 1f;
        int PlasticValue = Random.Range(0, 4);


        clone = Instantiate(Afval, Boat, Quaternion.Euler(new Vector3(0, 0, -45))) as GameObject;
        clone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * power, ForceMode2D.Impulse);
        clone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * power, ForceMode2D.Impulse);
        clone.GetComponent<SpriteRenderer>().sprite = PlasticSkins[PlasticValue];

        StartCoroutine(GooiAfval());
    }
}
