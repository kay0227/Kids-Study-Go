using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mon_sel : MonoBehaviour {


    public string[] sel_mon;
    public int u_lv;
    public int m_sel, m_num;
    public string m_code;
    

    // Use this for initialization
    public IEnumerator Start () {
        WWW monsel = new WWW("http://13.125.210.53/kids/battle/battle_monsel.php");
        yield return monsel;
        string monselString = monsel.text;

        sel_mon = monselString.Split(';');
        u_lv=int.Parse(GetDataValue(sel_mon[0], "u_level:"));

        print(u_lv);

        m_sel = u_lv/10 + 1;
        switch (m_sel) {
            case 1: //몬스터 레벨이 10 이하면 추출되는 몬스터 리스트 1개
                print("hi");
            m_code = GetDataValue(sel_mon[1], "code:");
                    //해당 몬스터코드 추출
                    //그 후 원하시는 프리펩 변경 코드 추가
                    break;
        
            case 2:
                print("start!");
            m_code = selectmonster(m_sel);
                //m_code을 이용하여 원하시는 프리펩 변경 코드 추가
                break;
            case 3:
        
            m_code = selectmonster(m_sel);
                //m_code을 이용하여 원하시는 프리펩 변경 코드 추가
                break;

            case 4:
        
            m_code = selectmonster(m_sel);
                //m_code을 이용하여 원하시는 프리펩 변경 코드 추가
                break;
            case 5:
                m_code = selectmonster(m_sel);
                //m_code을 이용하여 원하시는 프리펩 변경 코드 추가
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public string selectmonster(int m_sel)
    {
         //몬스터 리스트 2개 출력
        if(m_sel!=5)
            m_sel += 1;
        print("m_sel" + m_sel);
        m_num = UnityEngine.Random.Range(1, m_sel);
        m_code = pGetDataValue(sel_mon[m_num], "code:");
        return m_code;
        

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
