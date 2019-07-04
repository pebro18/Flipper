using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DataInserter : MonoBehaviour
{
    public float? inputTime = GameManager.Instance.TimeLimit;
    public string inputLevelName;
    public float? inputScore = GameManager.Instance.Score;
    LevelManager levelmanager;
    string CreateUserURL = "http://api.project1jaar2database.com/InsertUser.php";

    // voegt een object toe die naar de input field 
    void Start()
    {
        inputLevelName = SceneManager.GetActiveScene().name;
    }
    public void ActivateInstert()
    {
        string ScoreInString = string.Format("{0:0}",inputScore);
        string TimeInString = string.Format("{0:0}", inputTime);
        InsertData(inputLevelName, ScoreInString,TimeInString);
    }

    public void InsertData(string levelnaam, string score,string time)
    {
        WWWForm form = new WWWForm();
        form.AddField("levelnaamPost", levelnaam);
        form.AddField("scorePost", score);
        form.AddField("timePost",time);
        
        WWW www = new WWW(CreateUserURL, form);
    }
 
}

