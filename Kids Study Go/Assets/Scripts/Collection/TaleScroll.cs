using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaleScroll : MonoBehaviour
{
    public RectTransform List;
    public int count;
    private float pos;
    private float movepos = 10800; // movepos = 10800 - 10800/10 (나누는 값 : 화면에 보여질 공간)
    private bool IsScroll = false;

	void Start ()
    {
        pos = List.localPosition.x;
        movepos = List.rect.xMax - List.rect.xMax / count;
	}

    public void Right()
    {
        if(List.rect.xMin + List.rect.xMax/count == movepos) { }
        else
        {
            IsScroll = true;
            movepos = pos - List.rect.width / count;
            pos = movepos;
            StartCoroutine("scroll");
        }
    }

    public void Left()
    {
        if (List.rect.xMax + List.rect.xMax / count == movepos) { }
        else
        {
            IsScroll = true;
            movepos = pos - List.rect.width / count;
            pos = movepos;
            StartCoroutine("scroll");
        }
    }

    IEnumerable scroll()
    {
        while (IsScroll)
        {
            List.localPosition = Vector2.Lerp(List.localPosition, new Vector2(movepos, 0), Time.deltaTime * 5);
            if (Vector2.Distance(List.localPosition, new Vector2(movepos, 0)) < 0.1f)
            {
                IsScroll = false;
            }
            yield return null;
        }
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }
}