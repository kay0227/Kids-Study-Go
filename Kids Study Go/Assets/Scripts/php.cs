using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class php : MonoBehaviour {

    //맵 정보 검색하기
    private IEnumerator GetMapInfos(string word)
    {
        WWWForm form = new WWWForm();//php에 보낼 폼을 만듦

        //전해줄 정보 입력
        form.AddField("word", word);

        WWW webRequest = new WWW("http://127.0.0.1/GetMapInfo.php", form);//127.0.0.1은 로컬 호스트 주소

        yield return webRequest;//정보가 올 때까지 기다림

        if (webRequest.isDone)//잘되면
        {
            ShowResult(webRequest.text);
        }
        else//안되면
        {
            Debug.Log(webRequest.error);
        }
    }

    private void ShowResult(string text)
    {
        throw new NotImplementedException();
    }
}


