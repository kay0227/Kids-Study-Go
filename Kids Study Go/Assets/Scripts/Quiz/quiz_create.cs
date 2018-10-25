using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class quiz_create : MonoBehaviour
{

    public string[] words;
    public string wname;
    public string code;

    public Text word_text;
    //문제 텍스트 박스
    public Text word1;
    public Text word2;
    public Text word3;
    public Text word4;
    // 보기 텍스트 박스
    public GameObject w_image;
    // 이미지 추출

    public GameObject panel;
    public GameObject pane2;

    public Button change;
    public Button fail1;
    public Button fail2;
    public Button fail3;

    public Button change1;
    public Button fail11;
    public Button fail22;
    public Button fail33;

    public Button change2;
    public Button fail111;
    public Button fail222;
    public Button fail333;

    public Button change3;
    public Button fail1111;
    public Button fail2222;
    public Button fail3333;
    // Use this for initialization

    public void Awake()
    {
        panel.SetActive(false);
        pane2.SetActive(false);
    } // 페널 숨기기
    IEnumerator Start()
    {
        char[] w_cont;
        char[] fin_word = null;
        char search;
        char[] test = null;
        WWW wordData = new WWW("http://13.125.210.53/test/quiz_test.php");
        yield return wordData; // 다운로딩
        string wordDataString = wordData.text;
        string cos1 = null;
        char textEx1;
        //DontDestroyOnLoad(this.gameObject);
        //change.onClick.AddListener(SetActive);

        print(wordDataString);



        words = wordDataString.Split(';');


        wname = pGetDataValue(words[0], "Word:");
        code = GetDataValue(words[0], "Code:");

        Debug.Log(code);

        w_cont = wname.ToCharArray();
        // -> 문자 배열을 문자열로

        //Debug.Log(cos);
        System.Random r = new System.Random();
        int count = r.Next(0, wname.Length - 1);

        List<char> word = new List<char>(w_cont);
        //리스트에 배열값 삽입

        search = w_cont[count];

        word.RemoveAt(count);
        word.Insert(count, '□');
        //일정부분 제거 후 ㅁ로 대처


        fin_word = word.ToArray();
        //리스트를 배열로 전환

        string cos = new string(fin_word);
        //-> 문자배열 문자로


        w_image.GetComponent<Image>().sprite = Resources.Load("word/"+wname, typeof(Sprite)) as Sprite;
        word_text.text = cos;

        // 97 ~ 122 아스키 코드값

        List<char> num = new List<char>();
        for (int i = 97; i <= 122; i++)
        {
            num.Add((char)i);
        }

        test = num.ToArray();

        //System.Random ar = new System.Random();
        //int count1 = ar.Next(0, 25);

        if (num.Contains(search) == true)
        {
            textEx1 = search;
            cos1 = textEx1.ToString();
        }

        // word1.text = cos1;
        System.Random ar = new System.Random();
        int count1 = ar.Next(0, 3);
        int count2 = ar.Next(0, 10);
        int count3 = ar.Next(11, 18);
        int count4 = ar.Next(19, 25);

        char exx2, exx3, exx4;
        string ex2, ex3, ex4 = null;

        exx2 = test[count2];
        exx3 = test[count3];
        exx4 = test[count4];


        if (search == exx2)
        {
            while (true)
            {
                count2 = ar.Next(0, 10);

                if (search != exx2)
                {
                    exx2 = test[count2];
                    break;
                }
            }
        }

        else if (search == exx3)
        {
            while (true)
            {
                count3 = ar.Next(11, 18); ;

                if (search != exx3)
                {
                    exx3 = test[count3];
                    break;
                }

            }
        }

        else if (search == exx4)
        {
            while (true)
            {
                count4 = ar.Next(19, 25);

                if (search != exx4)
                {
                    exx4 = test[count4];
                    break;
                }

            }
        }

        ex2 = exx2.ToString();
        ex3 = exx3.ToString();
        ex4 = exx4.ToString();

        switch (count1)
        {
            case 0:
                word1.text = cos1;
                word2.text = ex2;
                word3.text = ex3;
                word4.text = ex4;

                change.onClick.AddListener(SetActive);
                fail1.onClick.AddListener(FailScene);
                fail2.onClick.AddListener(FailScene);
                fail3.onClick.AddListener(FailScene);
                break;
            case 1:
                word1.text = ex2;
                word2.text = cos1;
                word3.text = ex4;
                word4.text = ex3;

                change1.onClick.AddListener(SetActive);
                fail11.onClick.AddListener(FailScene);
                fail22.onClick.AddListener(FailScene);
                fail33.onClick.AddListener(FailScene);
                break;
            case 2:
                word1.text = ex3;
                word2.text = ex4;
                word3.text = cos1;
                word4.text = ex2;

                change2.onClick.AddListener(SetActive);
                fail111.onClick.AddListener(FailScene);
                fail222.onClick.AddListener(FailScene);
                fail333.onClick.AddListener(FailScene);
                break;
            case 3:
                word1.text = ex4;
                word2.text = ex3;
                word3.text = ex2;
                word4.text = cos1;

                change3.onClick.AddListener(SetActive);
                fail1111.onClick.AddListener(FailScene);
                fail2222.onClick.AddListener(FailScene);
                fail3333.onClick.AddListener(FailScene);
                break;
        }
    }
    // 답 확인

    void SetActive()
    {
        panel.SetActive(true);
        WWW codeData = new WWW("http://13.125.210.53/test/Qcounting.php");
        WWW ansData = new WWW("http://13.125.210.53/test/dfc.php");
        WWW plusStaData = new WWW("http://13.125.210.53/kids/word/PlusSta.php");

        WWWForm form = new WWWForm();
        form.AddField("Code", code);
        Debug.Log(wname);
        WWW plusExData = new WWW("http://13.125.210.53/kids/word/PlusExp.php", form);

        //맞췄을때
    }

    void FailScene()
    {
        pane2.SetActive(true);
    }
    //틀렸을때
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