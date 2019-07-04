using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlieSpawnerScript : MonoBehaviour {

    public GameObject CollisionBlok;
    public GameObject SpawnPointObject;
    public ParticleSystem OlieSpawner;
    public ParticleCollisionEvent[] CollisionEvents;
    public float Wachttijd;
    
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnOlie());
	}
    IEnumerator SpawnOlie()
    {
        yield return new WaitForSeconds(Wachttijd);
        OlieSpawner.Play();
        GameObject clone;
        Vector2 SpawnPoint = SpawnPointObject.transform.position;

        clone = Instantiate(CollisionBlok, SpawnPoint, Quaternion.identity) as GameObject;
        clone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
        StartCoroutine(SpawnOlie());

    }
   
}
