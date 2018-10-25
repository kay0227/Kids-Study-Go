using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePrefab : MonoBehaviour {
    public GameObject SpawnObject;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        KillLaser();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void KillLaser() { 
        Destroy(SpawnObject, 5.0f); //소멸시간 지정 후 삭제
    }

    /*
    Destroy(this.GameObject) 함수 추가 
    */
}
