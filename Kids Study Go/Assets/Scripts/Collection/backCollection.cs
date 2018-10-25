using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backCollection : MonoBehaviour {

	void Start () { }
	
	void Update () { }

    public void ChangeTaleScene()
    {
        SceneManager.LoadScene("Collection");
    }

    public void BackMain()
    {
        SceneManager.LoadScene("MainScreen");
    }

}