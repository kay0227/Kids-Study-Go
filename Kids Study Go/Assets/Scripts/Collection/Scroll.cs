using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    /* bnt_UP, bnt_DOWN Object */

    public Scroll_Mng mng = null;           // 스크롤 관리 파일
    public GameObject bnt_Scroll = null;    // 메뉴 오브젝트

    public void scroll_Up()
    {
        if (mng.cnt > 1)
        {
            bnt_Scroll.transform.localPosition -= new Vector3(0, 240);
            mng.cnt--;
        }
    }

    public void scroll_Down()
    {
        if (mng.cnt <= mng.m_Num - 6)   // if ( 메뉴 위치 <= 메뉴 갯수 - 출력 메뉴 갯수 )
        {
            bnt_Scroll.transform.localPosition += new Vector3(0, 240);
            mng.cnt++;
        }
    }
}
