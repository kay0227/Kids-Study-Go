using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class my_battle_act : MonoBehaviour {

    public Animator my_ani;
    public Animation ani;



	// Use this for initialization
	void Start () {
       
	}
    public void Awake()
    {
        // my_ani.Stop("my_act");
        my_ani.speed = 0.0f;
        
        

    }

    // Update is called once per frame
    public void myani_on () {
        Debug.Log("cc");
        my_ani.speed = 1.0f;
        my_ani.Play("my_act", -1, 0f);
	}
}
