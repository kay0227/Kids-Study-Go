using UnityEngine;
using System.Collections;

public class FairyDataLoader : MonoBehaviour {

	public string[] contents;

	IEnumerator Start(){
		WWW contentsData = new WWW("http://13.125.210.53/test/tale.php");
		yield return contentsData;
		string itemsDataString = contentsData.text;
		print (itemsDataString);
		contents = itemsDataString.Split(';');
		print(GetDataValue(contents[0], "Cost:"));
	}

	string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
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
