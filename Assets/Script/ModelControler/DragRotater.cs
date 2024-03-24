using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragRotater : MonoBehaviour, IDragHandler
{
    public float rotateSpeed = 10;

    public void OnDrag(PointerEventData eventData)
    {
        float x = eventData.delta.x * Time.deltaTime * rotateSpeed;
        float y = eventData.delta.y * Time.deltaTime * rotateSpeed;

        transform.Rotate(y, -x, 0, Space.World);

    }
}
