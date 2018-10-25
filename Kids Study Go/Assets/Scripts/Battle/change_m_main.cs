using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_m_main : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void ChangeGameScene() {
        SceneManager.LoadScene("MainScreen");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
