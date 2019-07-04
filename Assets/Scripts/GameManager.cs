using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
                go.AddComponent<DataInserter>();
            }
            return _instance;
        }
    }

    public float Score { get; set; }
    public float TimeLimit { get; set; }
    public float KoraalHP { get; set; }
    public float DolfijnHP { get; set; }

    bool Lost = false;
    bool Win = false;
    LevelManager levelmanager;
    UIController uiController;
    PlayerHealth playerHealth;
    DataInserter dataInserter;

    public void Victory()
    {
        uiController.ToggleWinScreen();
    }
    public void Lose()
    {
        uiController.ToggleLoseScreen();
    }

    void Update()
    {
        DolfijnHP = playerHealth.currentHealth;
        if (DolfijnHP <= 0 || KoraalHP <= 0)
        {
            if (Lost)
            {
                Lose();
                Lost = true;
                dataInserter.ActivateInstert();

            }
        }

        if(TimeLimit <= 0)
        {
            if (!Win)
            {
                Victory();
                Win = true;
                dataInserter.ActivateInstert();
            }
        }
        TimeLimit  -= Time.deltaTime;

        
    }
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1;
        TimeLimit = 180f;
        dataInserter = GameObject.FindObjectOfType<DataInserter>();
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        uiController = GameObject.FindObjectOfType<UIController>();
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
    }
}
