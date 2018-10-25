using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hiddenmission : MonoBehaviour
{
    public string[] tget;
    public string uhunt;
    public string uword;
    public string uquiz;
    public string ufairy;
    public int uhunt_i;
    public int uword_i;
    public int uquiz_i;
    public int ufairy_i;

    public GameObject mission3, book3, goldLock3, key3;
    public GameObject mission5, book5, goldLock5, key5;
    public GameObject mission6, book6, goldLock6, key6;
    public GameObject mission7, book7, goldLock7, key7;


    // Use this for initialization
    IEnumerator Start()
    {
        WWW topenData = new WWW("http://13.125.210.53/tale/hiddenmission.php");
        yield return topenData; // 다운로딩
        string topenDataString = topenData.text;
        print(topenDataString);


        tget = topenDataString.Split(';');

        uhunt = pGetDataValue(tget[0], "hunt:");
        uword = pGetDataValue(tget[0], "word:");
        uquiz = pGetDataValue(tget[0], "quiz:");
        ufairy = pGetDataValue(tget[0], "fairy:");

        if (uhunt != null)
        {
            uhunt_i = int.Parse(uhunt);     //15회

            if (uhunt_i > 14)
            {
                mission3.SetActive(false);
                book3.SetActive(true);
                goldLock3.SetActive(false);
                key3.SetActive(false);
            }
            
        }
        

        if (uword != null)
        {
            uword_i = int.Parse(uword);     //20회

            if (uword_i > 19)
            {
                mission7.SetActive(false);
                book7.SetActive(true);
                goldLock7.SetActive(false);
                key7.SetActive(false);
            }
            else { mission3.SetActive(true); }
        }
        else { }

        if (ufairy != null)
        {
            ufairy_i = int.Parse(ufairy);   //10회

            if (ufairy_i > 9)
            {
                mission6.SetActive(false);
                book6.SetActive(true);
                goldLock6.SetActive(false);
                key6.SetActive(false);
            }
            else { }
        }
        else { }

        if (uquiz != null)
        {
            uquiz_i = int.Parse(uquiz);     //10회

            if (uquiz_i > 9)
            {
                mission5.SetActive(false);
                book5.SetActive(true);
                goldLock5.SetActive(false);
                key5.SetActive(false);
            }
            else { }
        }
        else { }

    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        return value;
    }

    string pGetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
