using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
