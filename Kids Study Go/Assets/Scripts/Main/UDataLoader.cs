using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UDataLoader : MonoBehaviour
{

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
    IEnumerator Start()
    {
        WWW UserData = new WWW("http://13.125.210.53/kids/main/UserInfo.php");
        yield return UserData;
        string UserDataString = UserData.text;
        User = UserDataString.Split(';');

        u_nic = uGetDataValue(User[0], "Name:");
        u_level = uGetDataValue(User[0], "Level:");
        u_hp = uGetDataValue(User[0], "Hp:");
        u_sp = uGetDataValue(User[0], "Staminar:");
        u_exp = uGetDataValue(User[0], "Exp:");

        ID.text = u_nic;
        Level.text = "Lv." + u_level;
        HP.text = u_hp;
        SP.text = u_sp;
        EXP.text = u_exp;
        ATK.text = Convert.ToString(Convert.ToInt32(u_level) * 5);
        DEF.text = Convert.ToString(Convert.ToInt32(u_level) * 2);
    }

    string uGetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    // Update is called once per frame
    void Update()
    {

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
