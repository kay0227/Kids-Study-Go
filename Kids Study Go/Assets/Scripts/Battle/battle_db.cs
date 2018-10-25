using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class battle_db : MonoBehaviour {

    public string[] monster;
    public Text ene_text;
    public Text my_text;
    public Text p_text;
    public string oname;
    public int level,maxlv,m_exp;
    public int u_marble;
    public GameObject ene_image;
    public Slider my_sli;
    public Slider ene_sli;
    public float ene_att, my_att, my_def;
    public string u_name;
    public int u_lv,u_lvplus,u_exp;
    public float m_hp;

    //public int m_code; //후 처리필요



    // Use this for initialization
    public void Start() {
        StartCoroutine(Createmonster());
    }

    public IEnumerator Createmonster() {

        WWWForm monsterdata = new WWWForm();
        monsterdata.AddField("moncodePost",ChangeMonsterPrefab.m_code);
        WWW sel_monster = new WWW("http://13.125.210.53/kids/battle/battle_mon.php", monsterdata);
        yield return sel_monster;
        string monsterdataString = sel_monster.text;

        monster = monsterdataString.Split(';');
        print(monsterdataString);
        u_lv = int.Parse(pGetDataValue(monster[0], "level:Lv."));
        u_name = pGetDataValue(monster[0], "name:");
        my_text.text = "Lv."+u_lv + " " + u_name;
        
        level = int.Parse(pGetDataValue(monster[1], "level:Lv."));

        oname = pGetDataValue(monster[1], "name:");

        m_exp = int.Parse(pGetDataValue(monster[1], "m_exp:"));
        u_exp = int.Parse(pGetDataValue(monster[0], "exp:"));


        maxlv =(level /10 + 1)*10;
        
        level--;
        u_lvplus = u_lv + 3;
        if(maxlv>=u_lv)
        level = UnityEngine.Random.Range(level,u_lvplus);
        else level = UnityEngine.Random.Range(level,maxlv);


        ene_text.text = "Lv."+level + " " + oname;
        ene_image.GetComponent<Image>().sprite = Resources.Load(oname,typeof(Sprite)) as Sprite;

        p_text.text = "야생의  " + oname + "가(이) 나타났다!";
    

       m_hp= float.Parse(GetDataValue(monster[1],"m_hp:"));
        ene_sli.maxValue = m_hp + (30 * (level % 10));
       my_sli.maxValue = float.Parse(pGetDataValue(monster[0],"u_hp:"));
        ene_sli.value = ene_sli.maxValue;
        my_sli.value = my_sli.maxValue;

        my_att = float.Parse(pGetDataValue(monster[0],"att:"));
        ene_att=float.Parse(pGetDataValue(monster[1],"att:"));
        if(level>10)
            ene_att = ene_att + (20 * ((level-1) % 10));
        else ene_att = ene_att + (20 * (level % 10));
        my_def = float.Parse(GetDataValue(monster[0], "def:"));

       
        if (level > 10)
            m_exp = m_exp + (5 * ((level-1) % 10));
        else m_exp = m_exp + (5 * (level % 10));
    }

    public string GetDataValue(string data, string index) {
        string value = data.Substring(data.IndexOf(index)+index.Length);
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
