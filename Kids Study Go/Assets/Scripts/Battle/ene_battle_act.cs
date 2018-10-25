using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ene_battle_act : MonoBehaviour {

    public Animator ene_ani;
    public Animation e_ani;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Awake () {
        ene_ani.speed = 0.0f;
	}
    public void eneani_on() {
        ene_ani.speed = 1.0f;
        ene_ani.Play("ene_act", -1, 0f);
    }
}
