using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenTale4 : MonoBehaviour
{
    public string[] topen;
    public string tcode;
    public string tget;
    public GameObject open;
    public int tget_i;

    // Use this for initialization
    IEnumerator Start()
    {
        WWW topenData = new WWW("http://13.125.210.53/tale/tale_open4.php");
        yield return topenData; // 다운로딩
        string topenDataString = topenData.text;
        print(topenDataString);

        topen = topenDataString.Split(';');


        tcode = pGetDataValue(topen[0], "Code:");
        tget = GetDataValue(topen[0], "get:");

        tget_i = int.Parse(tget);

        if (tcode == "4" | tget_i > 6)
            open.SetActive(true);
        else
            open.SetActive(false);
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
