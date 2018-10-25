using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class m_reward : MonoBehaviour {

    public GameObject reward_O;
    public GameObject reward_C;
    public GameObject exp;
    public GameObject fpiece;
    public GameObject m_rback;
    public Text exp_text;


    // Use this for initialization
    void Start () {
		
	}
    void Awake()
    {
        reward_O.SetActive(false);
        exp.SetActive(false);
        fpiece.SetActive(false);
    }

    public void mon_reward() {

        battle_db batdb = GameObject.Find("battle").GetComponent<battle_db>();
        exp_text.text = "+"+batdb.m_exp+"";

        reward_C.SetActive(false);
        reward_O.SetActive(true);
        var attack =GameObject.Find("attack").GetComponent<mon_attack>();
        if(attack.rate>0 && attack.rate<7)
        fpiece.SetActive(true);
        
       else { fpiece.SetActive(false); }

        exp.SetActive(true);
        Invoke("act_m_rba",1);
    }

    void act_m_rba() {
        m_rback.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}


   

}
