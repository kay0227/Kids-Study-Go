using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.EventSystems;

public class Helpme : MonoBehaviour
{

    public string[] words;
    public string wcode;
    public string wname;
    public string wdefi;
    public Text word_text;
    public Text word_defi;
    public GameObject w_image;
    public AudioClip sound1;

    public string postWord;


    private AudioSource source
    {
        get
        {
            return GetComponent<AudioSource>();
        }
    }

    public Button sound;

    // Use this for initialization

    IEnumerator Start()
    {
        WWW wordData = new WWW("http://13.125.210.53/test.php");
        WWW codeData = new WWW("http://13.125.210.53/test/counting.php");
        

        yield return codeData;
        yield return wordData; // 다운로딩

        //print(wordDataString);
        string wordDataString = wordData.text;
        string codeDataString = codeData.text;

        words = wordDataString.Split(';');
        //분류
        wcode = pGetDataValue(words[0], "Code:");
        wname = pGetDataValue(words[0], "Word:");
        wdefi = GetDataValue(words[0], "Wordde:");

        WWWForm form = new WWWForm();
        form.AddField("Contact", wcode);
        Debug.Log(wcode);
        WWW plusWord = new WWW("http://13.125.210.53/test/uWordPlus.php", form);

        yield return plusWord;


        gameObject.AddComponent<AudioSource>();
        source.clip = sound1;
        source.playOnAwake = false;

        w_image.GetComponent<Image>().sprite = Resources.Load("word/"+wname, typeof(Sprite)) as Sprite;
        AudioClip clip1 = Resources.Load("sound/"+wname, typeof(AudioClip)) as AudioClip;

        sound1 = clip1;

        word_text.text = wname;
        word_defi.text = wdefi;

        sound.onClick.AddListener(SetActive);
    }


    void SetActive()
    {
        source.PlayOneShot(sound1);
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
