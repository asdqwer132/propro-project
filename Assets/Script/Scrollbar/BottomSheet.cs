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
        if (Input.GetMouseButtonUp(0) && (scrollbar.value > 0.05f && scrollbar.value < 0.95f))//���� ���콺�� �ڵ� ����� �������������� �𸣰���
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
