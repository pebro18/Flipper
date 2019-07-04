using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject[] UiObjects;
    public Slider[] UIHealth;
    public Text[] UIElementsText;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ToggleUI();

        if (UiObjects[0].activeSelf || UiObjects[3].activeSelf || UiObjects[4].activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

       // UIHealth[0].value = GameManager.Instance.DolfijnHP / 100;
        UIHealth[1].value = GameManager.Instance.KoraalHP;

        UIElementsText[0].text = "Time: " + string.Format("{0:0}", GameManager.Instance.TimeLimit) ;
        //UIElementsText[1].text = /*Hoeveelheid afval later toevoegen +*/  "0/3"  ;
        UIElementsText[2].text = "" + GameManager.Instance.Score;
    }
    public void ToggleUI()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UiObjects[0].SetActive(!UiObjects[0].activeSelf);
            if (UiObjects[1].activeSelf)
            {
                UiObjects[1].SetActive(false);
            }
        }
    }
    public void ClickToggleUI()
    {
        UiObjects[0].SetActive(!UiObjects[0].activeSelf);
        if (UiObjects[1].activeSelf)
        {
            UiObjects[1].SetActive(false);
        }
    }
    public void ClickToggleOptions()
    {
        UiObjects[1].SetActive(!UiObjects[1].activeSelf);
    }
    public void ToggleWinScreen()
    {
        UiObjects[3].SetActive(!UiObjects[3].activeSelf);
    }
    public void ToggleLoseScreen()
    {
        UiObjects[4].SetActive(!UiObjects[4].activeSelf);
    }
}
