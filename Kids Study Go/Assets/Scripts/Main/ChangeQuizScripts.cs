using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeQuizScripts : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeWordScene()
    {
        //SceneManager.LoadScene("");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        SceneManager.LoadScene("Quiz");
        //Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        //SceneManager.LoadScene("");
        //Debug.Log("Mouse Up");
    }
}
