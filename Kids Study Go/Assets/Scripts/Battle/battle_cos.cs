using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class battle_cos : MonoBehaviour {

    public string[] user;
    int u_lv,u_exp;
    public int info_ulv, info_uexp;

	// Use this for initialization
	void Start () {
        

    }
    public void Costmove()
    {
        StartCoroutine(Userinfo());
       

    }

    public IEnumerator Userinfo()
    {

        WWW monsterdata = new WWW("http://13.125.210.53/kids/battle/battle_mon.php");
        yield return monsterdata;
        string monsterdataString = monsterdata.text;

        user = monsterdataString.Split(';');
        info_ulv = int.Parse(pGetDataValue(user[0], "level:Lv."));
        info_uexp = int.Parse(pGetDataValue(user[0], "exp:"));

        if(info_ulv%5==0&&info_uexp==0)
        {
         
            SceneManager.LoadScene("Costurm");
        }
        else
        {
            SceneManager.LoadScene("MainScreen");
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
