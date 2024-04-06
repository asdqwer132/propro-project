using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScrollViewBtn : ScrollbarMover
{
    public GameObject[] scrollBars;
    public TextChanger[] btnTexts;
    public int maxBtnCount;

    public void Open(int index)
    {
        if (scrollBars.Length <= index) return;
        for(int i = 0; i < scrollBars.Length; i++)
        {
            scrollBars[i].SetActive(false);
        }
        scrollBars[index].SetActive(true);
        MoveScrollbar(scrollbar.value,index / maxBtnCount);
        SetColor(index);
    }
    void SetColor(int index)
    {
        for(int i=0;i<maxBtnCount + 1; i++)
        {
            btnTexts[i].SetColor(new Color(0.6f, 0.6f, 0.6f));
        }
        btnTexts[index].SetColor(Color.black);
    }
}
