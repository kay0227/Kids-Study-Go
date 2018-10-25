using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class ChangeBattleScripts : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    string toastString;
    string input;
    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;

    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void ChangeBattleScene()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        WWWForm StaminaSet = new WWWForm();
        StaminaSet.AddField("Output_user", LoginManager.webRequest.text.ToString());

        if (Convert.ToInt32(StaminaBarScripts.stamina) >= 10)
        {
            SceneManager.LoadScene("mon_battle");

            //StaminaSet.AddField("StaminaPost", );
            WWW StaminaSetting = new WWW("http://13.125.210.53/kids/main/StaminaSet.php", StaminaSet);
        }
        else
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                showToastOnUiThread("스태미너가 부족합니다!"); //유니티 상에서는 안보임!! 반드시 안드로이드 기기로 실행 요구
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    void showToastOnUiThread(string toastString)
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        this.toastString = toastString;

        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
    }

    void showToast()
    {
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }
}
