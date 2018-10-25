using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class battleGo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void ChangeBattleScene() {
        SceneManager.LoadScene("mon_battle");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
