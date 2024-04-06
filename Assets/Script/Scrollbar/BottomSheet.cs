using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomSheet : ScrollbarMover
{
    public float middlePoint;
    float max = 1f;
    float min = 0f;
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && (scrollbar.value > 0.05f && scrollbar.value < 0.95f))//현재 마우스로 코딩 모바일 대응가능한지는 모르겠음
        {
            Debug.Log("asd");
            float target = middlePoint > scrollbar.value ? min : max;
            MoveScrollbar(scrollbar.value, target);
        }
    }
    public void Close()
    {
        MoveScrollbar(scrollbar.value, min);
    }
}
