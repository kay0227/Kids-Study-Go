using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class mon_attack : MonoBehaviour {

   string editmonURL = "http://13.125.210.53/kids/battle/reward_addfairy.php";
    

    [Header("game_object")]
    public Slider ene_Slider;  //reference for slider
    public Slider my_Slider;
    public GameObject fpiece;



    public int rate;
    public string[] fairy_list;
    public int r_num;
    public string code_fairy;
    public string re_fairy;
    public float e_att;

    public Text piece;


    [Header("panel")]
    public GameObject win;
    public GameObject lose;
    public GameObject m_rback;
    public GameObject p_none;
    public bool re = false;
    public bool att = false;


    // Use this for initialization
   void Start () {
	}


    private void Awake()
    {
       

        win.SetActive(false);
        lose.SetActive(false);
        m_rback.SetActive(false);
        p_none.SetActive(false);

    }

   

    public void Attack()
    {

        p_none.SetActive(true);
        battle_db batdb = GameObject.Find("battle").GetComponent<battle_db>();

        if (ene_Slider.value > 0)
        {
            if (my_Slider.value > 0)
                GameObject.Find("my_Image").GetComponent<my_battle_act>().myani_on();
            ene_Slider.value -= batdb.my_att;
            if (ene_Slider.value <= 0) {
                re = true;
                Invoke("Waitresult", 1);

            }
             else   Invoke("Attacked", 1);
        }

    }
   
    public void Attacked() {

        battle_db batdb = GameObject.Find("battle").GetComponent<battle_db>();

        if (my_Slider.value > 0)
        {
            if (ene_Slider.value > 0)
                GameObject.Find("ene_Image").GetComponent<ene_battle_act>().eneani_on();
            if (batdb.my_def != 0)
            {
                e_att = batdb.ene_att - batdb.ene_att * batdb.my_def / 100;
                my_Slider.value -= e_att;
            }
            else my_Slider.value -= batdb.ene_att;  //reduce health
            if (my_Slider.value <= 0)
            {
                re = false;
                Invoke("Waitresult", 1);
            }
            p_none.SetActive(false);
        }
        
    }

    public void Waitresult()
    {
        battle_db batdb = GameObject.Find("battle").GetComponent<battle_db>();
        if(re)
        { 
            win.SetActive(true);

            WWW mcount = new WWW("http://13.125.210.53/kids/battle/battle_moncount.php");

            WWWForm addexp = new WWWForm();
            addexp.AddField("expdataPost", batdb.m_exp);
            WWW addexpdata = new WWW("http://13.125.210.53/kids/battle/battle_exp.php", addexp);
            

            rate = UnityEngine.Random.Range(1, 11);

            if (rate < 7 && rate > 0)
            {
                StartCoroutine(Fa_reward());
            }
        }
        else {
            lose.SetActive(true);
            Invoke("act_m_rba", 1);
        }
    }
   
    void act_m_rba() {
        m_rback.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator Fa_reward()
    {
        
        //ene_text = GetComponent<Text>();
        WWW fairy = new WWW("http://13.125.210.53/kids/battle/mon_reward.php");
        yield return fairy;
        string fairydataString = fairy.text;
        // print(monsterdataString);

        fairy_list = fairydataString.Split(';');
        print(fairy_list);
        r_num = UnityEngine.Random.Range(0, 8);


        code_fairy = pGetDataValue(fairy_list[r_num], "code:");

        re_fairy = GetDataValue(fairy_list[r_num], "subject:");

        piece.text = re_fairy;

        print(code_fairy);
        WWWForm fairyf = new WWWForm();
        fairyf.AddField("fairycodePost", code_fairy);

        WWW addfairy = new WWW(editmonURL, fairyf);
        yield return addfairy;
        string addfairydata = addfairy.text;
        

 
    }



    IEnumerator Mon_reward() {
     
        //ene_text = GetComponent<Text>();
        WWW fairy = new WWW("http://13.125.210.53/kids/battle/mon_reward.php");
        yield return fairy;
        string fairydataString = fairy.text;
        // print(monsterdataString);

        fairy_list = fairydataString.Split(';');
        print(fairy_list);
        r_num = UnityEngine.Random.Range(0, 8);


        code_fairy = pGetDataValue(fairy_list[r_num], "code:");

        re_fairy = GetDataValue(fairy_list[r_num], "subject:");

        piece.text = re_fairy;

        print(code_fairy);
        WWWForm fairyf = new WWWForm();
        fairyf.AddField("fairycodePost", code_fairy);

        WWW addfairy = new WWW(editmonURL, fairyf);
        yield return addfairy;
        string addfairydata = addfairy.text;


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
