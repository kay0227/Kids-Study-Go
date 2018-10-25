using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lv_costume : MonoBehaviour {

    public string[] costdata;
    public string cos_name,cimg_path;
    public int c_def, c_atk;
    public GameObject marbleimg;
    public Text content;

    // Use this for initialization
    public IEnumerator Start()
    {
        WWW costume = new WWW("http://13.125.210.53/kids/battle/battle_costume.php");
        yield return costume;
        string costdataString = costume.text;
        costdata = costdataString.Split(';');
        print(costdataString);


        cos_name = pGetDataValue(costdata[0], "c_name:");
        c_def = int.Parse(pGetDataValue(costdata[0], "c_def:"));
        c_atk = int.Parse(pGetDataValue(costdata[0], "c_atk:"));
        cimg_path = GetDataValue(costdata[0], "c_img:");
        marbleimg.GetComponent<Image>().sprite = Resources.Load(cimg_path, typeof(Sprite)) as Sprite;

        if (c_def == 0)
            content.text = cos_name + "을 획득했습니다! 공격력이 +" + c_atk + "% 증가됩니다.";
        else if (c_atk == 0) {
            content.text = cos_name + "을 획득했습니다! 방어력이 +" + c_def + " 증가됩니다.";
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        // value = value.Remove(value.IndexOf("|"));
        return value;
    }



    public string pGetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
