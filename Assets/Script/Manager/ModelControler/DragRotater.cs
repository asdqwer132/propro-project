using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragRotater : MonoBehaviour, IDragHandler
{
    //public enum Direction { left, right, up, down };
    public float rotateDragSpeed = 50;
    public float rotateBtnSpeed = 0.01f;
    public GameObject target;
    string direction;
    public bool m_IsButtonDowning;

    private void Update()
    {
        if (m_IsButtonDowning)
        {
            switch (direction)
            {
                case "left":
                    target.transform.Rotate(0, rotateBtnSpeed, 0, Space.World);
                    break;
                case "right":
                    target.transform.Rotate(0, -rotateBtnSpeed, 0, Space.World);
                    break;
                case "up":
                    target.transform.Rotate(rotateBtnSpeed, 0, 0, Space.World);
                    break;
                case "down":
                    target.transform.Rotate(-rotateBtnSpeed, 0, 0, Space.World);
                    break;
            }
            
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        float x = eventData.delta.x * Time.deltaTime * rotateDragSpeed;
        float y = eventData.delta.y * Time.deltaTime * rotateDragSpeed;
        target.transform.Rotate(y, -x, 0, Space.World);
    }
    public void PointerDown(string direction)
    {
        this.direction = direction;
        m_IsButtonDowning = true;
    }
    public void PointerUp()
    {
        m_IsButtonDowning = false;
    }
}
