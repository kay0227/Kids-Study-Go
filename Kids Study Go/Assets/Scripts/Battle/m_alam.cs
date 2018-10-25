using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class m_alam : MonoBehaviour {


	// Use this for initialization
	void Start () {
      //  setDisable();
       // Invoke("open", 1);
        Destroy(gameObject, 2);
    }
    /*
    void Awake()
    {
       // setDisable();
    }

    void setDisable()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    }
    void open()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 0);
        gameObject.SetActive(true);

    }

    public void close()
    {
        setDisable();
    }
    */

    // Update is called once per frame
    void Update () {
		
	}
}
