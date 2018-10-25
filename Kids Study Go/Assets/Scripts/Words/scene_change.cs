using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_change : MonoBehaviour {

	// Use this for initialization
	public void SceneChange()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
