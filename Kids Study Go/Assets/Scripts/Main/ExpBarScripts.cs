using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Linq;

public class ExpBarScripts : MonoBehaviour
{
    public Image ExpBarImg;
    public float MaxExp;
    public float CurExp;
    public string[] User;
    public string u_exp;
    public string[] exparray;

    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("Output_user", LoginManager.webRequest.text.ToString());

        WWW UserData = new WWW("http://13.125.210.53/kids/main/UserInfo.php", form);
        yield return UserData;
        string UserDataString = UserData.text;
        User = UserDataString.Split(';');

        u_exp = GetDataValue(User[0], "Exp:");

        exparray = u_exp.Split('/');
        int[] intArray = new int[exparray.Count()];
        for (int i = 0; i < intArray.Count(); i++)
        {
            intArray[i] = Convert.ToInt32(exparray[i]);
        }
        CurExp = intArray[0];
        MaxExp = intArray[1];

        ExpBarImg.fillAmount = CurExp / MaxExp;
    }

    string GetDataValue(string data, string index)
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


    
 */
