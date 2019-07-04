using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour {

    public GameObject FishSpawnerObject;
    public GameObject Fish;
    public float WaitingTime;


	// Use this for initialization
	void Start () {
        StartCoroutine(FishSpawner());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FishSpawner()
    {
        yield return new WaitForSeconds(WaitingTime);
        Vector2 Position = FishSpawnerObject.transform.position;
        
        float X = Area(Position, 0);
        float Y = Area(Position, 1);
        Vector2 positionReady = new Vector2(X, Y); 
        GameObject clone =Instantiate(Fish,positionReady,Quaternion.identity) as GameObject;
        clone.GetComponent<FishMovement>().patrolDest = GameObject.Find("fish point").transform;
        StartCoroutine(FishSpawner());
    }

    float Area(Vector2 Position,int Axes) {

        Vector2 Size = GetComponent<BoxCollider2D>().bounds.size;
        float AxesSize = Size[Axes];
        float minAxes = AxesSize * -1;
        float floatAxes = Random.Range(minAxes, AxesSize);
        float PositionAxes = Position[Axes];
        float PositionFloat = PositionAxes + floatAxes;

        return PositionFloat;
    }
}
