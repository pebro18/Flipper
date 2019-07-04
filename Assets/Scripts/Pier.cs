using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pier : MonoBehaviour
{
    public float addScore;

    public Text scoreText;

    [HideInInspector] public bool atPier;
    [HideInInspector] public float currentScore;
    [HideInInspector] public float highScore;

    void Update()
    {
        GameManager.Instance.Score = currentScore;
        scoreText.text = "Score: " + currentScore;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Entered pier");
            atPier = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Exited pier");
            atPier = false;
        }
    }

}
