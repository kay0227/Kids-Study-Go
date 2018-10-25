using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Data;
using System.Linq;
using System;

public class StaminaBarScripts : MonoBehaviour {

    public Slider StmBarSlider;  //reference for slider
    static public float stamina;
    public float max_stamina;
    public string[] User;
    public string u_sp;
    public string[] sparray;

    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("Output_user", LoginManager.webRequest.text.ToString());

        WWW UserData = new WWW("http://13.125.210.53/kids/main/UserInfo.php", form);
        yield return UserData;
        string UserDataString = UserData.text;
        User = UserDataString.Split(';');

        u_sp = GetDataValue(User[0], "Staminar:");

        sparray = u_sp.Split('/');
        int[] intArray = new int[sparray.Count()];
        for (int i = 0; i < intArray.Count(); i++)
        {
            intArray[i] = Convert.ToInt32(sparray[i]);
        }
        stamina = intArray[0];
        max_stamina = intArray[1];

        StmBarSlider.value = stamina / max_stamina;
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