using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject Peaces = null;

    public void pop_Peaces()
    {
        if(Peaces.activeSelf)
            Peaces.SetActive(false);
        else
            Peaces.SetActive(true);
    }
}
