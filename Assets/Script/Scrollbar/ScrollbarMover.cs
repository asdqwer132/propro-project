using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollbarMover : MonoBehaviour
{
    public Slider scrollbar;
    float startPos;
    float currentPos;
    float targetPos;
    public float minus = 0.05f;
    public float wait = 0.005f;


    public void MoveScrollbar(float start, float target)
    {
        SetPos(start, target);
        SetScrollbar();
    }
    void SetPos(float start, float target)
    {
        targetPos = target;
        startPos = start;
    } 
    void SetScrollbar()
    {
        StopAllCoroutines();
        currentPos = startPos;
        StartCoroutine(Move(startPos - targetPos > 0));
    }

    IEnumerator Move(bool isLeft)
    {
        while (true)
        {
            if (isLeft)
            {
                if (targetPos > currentPos) break;
                currentPos -= minus;
            }
            else
            {
                if (targetPos < currentPos) break;
                currentPos += minus;
            }
            scrollbar.value = currentPos;
            if (scrollbar.value < 0.1f) scrollbar.value = 0;
            if (scrollbar.value > 0.9f) scrollbar.value = 1;
            yield return new WaitForSeconds(wait);
        }
    }
}
