using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float chasingRange;
    public float chasingSpeed;

    public Transform player;

    private float waitTime;
    public float startWaitTime;

    public float damage;

    [Header("Swim Range")]
    public Transform patrolDest;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        waitTime = startWaitTime;

        patrolDest.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolDest.position.x > transform.position.x)
        {
            //face right
            //transform.localScale = new Vector3(-0.5f, 0.6f, 0);
            transform.Rotate(0, 0, 0);
        }
        else if (patrolDest.position.x < transform.position.x)
        {
            //face left
            //transform.localScale = new Vector3(0.5f, 0.6f, 0);
            transform.Rotate(0, 180, 0);
        }

        if (Vector2.Distance(transform.position, player.position) < chasingRange)
        {
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, chasingSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolDest.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, patrolDest.position) < .2f)
            {
                if (waitTime <= 0)
                {
                    patrolDest.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    var hit = col.gameObject;
    //    var health = hit.GetComponent<DolphinController>();

    //    if (col.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Damaged");
    //        health.TakeDamage(10);
    //    }
    //}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingRange);
    }

}
