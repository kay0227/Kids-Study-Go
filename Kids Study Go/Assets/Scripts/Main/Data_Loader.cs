using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Data_Loader : MonoBehaviour {

    public string[] User;
    public string u_nic;
    public string u_level;
    public string u_hp;
    public string u_sp;
    public string u_exp;
    public Text ID;
    public Text Level;
    public Text HP;
    public Text SP;
    public Text EXP;
    public Text ATK;
    public Text DEF;

    // Use this for initialization
    IEnumerator Start () {

        WWWForm form = new WWWForm();
        form.AddField("Output_user", LoginManager.webRequest.text.ToString());

        //Debug.Log("DataLoader's code : " + UserCode); //test code
        //Debug.Log("DataLoader webRequest : " + LoginManager.webRequest.text.ToString()); //test code

        WWW UserData = new WWW("http://13.125.210.53/kids/main/UserInfo.php", form);
        yield return UserData;
        string UserDataString = UserData.text;
        User = UserDataString.Split(';');

        u_nic = GetDataValue(User[0], "Name:");
        u_level = GetDataValue(User[0], "Level:");
        u_hp = GetDataValue(User[0], "Hp:");
        u_sp = GetDataValue(User[0], "Staminar:");
        u_exp = GetDataValue(User[0], "Exp:");

        ID.text = u_nic;
        Level.text = "Lv." + u_level;
        HP.text = u_hp;
        SP.text = u_sp;
        EXP.text = u_exp;
        ATK.text = Convert.ToString(20 + (Convert.ToInt32(u_level) - 1) * 15); //1렙 20, 증가치 15
        DEF.text = Convert.ToString(Convert.ToInt32(u_level) / 5 * 10); // 마력구슬 갯수*10 (마력구슬 5렙당 1개 지급으로 임시처리)
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index)+index.Length);
        if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

/*
print(UserDataString);
print(GetDataValue(User[0], "Name : "));

print(u_nic);
print(u_level);
print(u_hp);
print(u_sp);
print(u_exp);

print(ID.text);
print(Level.text);
print(ATK.text);
print(HP.text);
print(SP.text);
print(EXP.text);

my_text.text = GetDataValue(monster[0], "level:");

level = pGetDataValue(monster[1], "level:");
oname = GetDataValue(monster[1], "name:");
ene_text.text = level + oname;

print(level);
p_text.text = "야생의 " + oname + "가(이) 나타났다!";
*/
