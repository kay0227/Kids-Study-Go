using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour {

    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PSInputField;

    [Header("CreateAccountPanel")]
    public InputField NewIDInputField;
    public InputField NewPSInputField;
    public GameObject CreateAccountPanelObj;

    [Header("ToastMessage")]
    string toastString;
    string input;
    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;

    public string LoginURL;
    public string CreateURL;
    static public WWW webRequest;

    //static public string UserCode;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        LoginURL = "http://13.125.210.53/kids/main/Login.php";
        CreateURL = "http://13.125.210.53/kids/main/CreateAccount.php";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //LoginPanel 버튼----------------------------------
    public void StartBtn()
    {
        StartCoroutine(StartCo());
    }

    IEnumerator StartCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("Input_user", IDInputField.text);
        form.AddField("Input_pass", PSInputField.text);

        //Debug.Log(IDInputField.text); //test code
        //Debug.Log(PSInputField.text); //test code

        webRequest = new WWW(LoginURL, form);
        yield return webRequest;

        //Debug.Log("webRequest.text : " + webRequest.text); //test code
        //Debug.Log("webRequest.text.ToString() : " + webRequest.text.ToString()); //test code
        //Debug.Log("HasKey : " + PlayerPrefs.HasKey("Usercode")); //test code
        //Debug.Log(DataThrower.Userdata); //test code
        //Debug.Log("LoginUserCode : " + UserCode); //test code

        if (Int32.Parse(webRequest.text) > 0) SceneManager.LoadScene("MainScreen");
        else
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                showToastOnUiThread("아이디가 없거나, 비밀번호가 다릅니다."); //유니티 상에서는 안보임!! 반드시 안드로이드 기기로 실행 요구
            }
        }
    }

    public void CreateAccountBtn()
    {
        CreateAccountPanelObj.SetActive(true);
    }

    //CreateAccountPanel 버튼--------------------------
    public void NewCreateAccountBtn()
    {
        StartCoroutine(CreateCo());
    }

    IEnumerator CreateCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("Input_user", NewIDInputField.text);
        form.AddField("Input_pass", NewPSInputField.text);

        Debug.Log(IDInputField.text); //test code
        Debug.Log(PSInputField.text); //test code

        WWW webRequest = new WWW(CreateURL, form);
        yield return webRequest;

        //Debug.Log(webRequest.text); //test code

        CreateAccountPanelObj.SetActive(false);
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
