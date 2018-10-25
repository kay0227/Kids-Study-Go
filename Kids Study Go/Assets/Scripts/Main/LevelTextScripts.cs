using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextScripts : MonoBehaviour {
    public string[] User;
    public Text LevelText;
    public string u_level;

    // Use this for initialization
    IEnumerator Start () {
        WWWForm form = new WWWForm();
        form.AddField("Output_user", LoginManager.webRequest.text.ToString());

        WWW UserData = new WWW("http://13.125.210.53/kids/main/UserInfo.php", form);
        yield return UserData;
        string UserDataString = UserData.text;
        User = UserDataString.Split(';');

        u_level = GetDataValue(User[0], "Level:");

        LevelText.text = u_level;
	}

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
