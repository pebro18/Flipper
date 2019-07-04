using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataLoader : MonoBehaviour {

	public string[] items;

    public Text[] Scoreboard;


    // Database lader voor het savestate
    IEnumerator Start(){
		WWW itemsData = new WWW("http://api.project1jaar2database.com/db_connect.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print (itemsDataString);

        items = itemsDataString.Split(';');

        for (int i = 0; i < Scoreboard.Length; i++)
        {
            // finish this dammit 
            Scoreboard[i].text = (GetDataValue(items[i], "score" + "tijd" + "levelnaam:"));
        }
    }

	string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);

		
		return value;
	}


}

//void Start(){
//	string data = "ID:1|Name:Health Potion|Type:consumables|Cost:50";
//	print(GetDataValue(data, "Cost:"));
//}
//
//void Update(){
//	
//}
//
//string GetDataValue(string data ,string index){
//	string value = data.Substring(data.IndexOf(index)+index.Length);
//	if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
//	return value;
//}
