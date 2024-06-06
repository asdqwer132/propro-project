using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragRotater : MonoBehaviour, IDragHandler
{
    //public enum Direction { left, right, up, down };
    public float rotateDragSpeed = 50;
    public float rotateBtnSpeed = 0.01f;
    public GameObject[] target;
    public Toggle rotateTogether;
    string direction;
    bool m_IsButtonDowning;

    private void Update()
    {
        if (m_IsButtonDowning)
        {
            switch (direction)
            {
                case "left":
                    Rotate(0, rotateBtnSpeed, 0);
                    break;
                case "right":
                    Rotate(0, -rotateBtnSpeed, 0);
                    break;
                case "up":
                    Rotate(rotateBtnSpeed, 0, 0);
                    break;
                case "down":
                    Rotate(-rotateBtnSpeed, 0, 0);
                    break;
            }
            
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        float x = eventData.delta.x * Time.deltaTime * rotateDragSpeed;
        float y = eventData.delta.y * Time.deltaTime * rotateDragSpeed;
        Rotate(y, -x, 0);
    }
    public void ResetRotate()
    {
        for (int i = 1; i < target.Length; i++)
            target[i].transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0)); ;
    }
    void Rotate(float x, float y, float z)
    {
        target[0].transform.Rotate(x, y, z, Space.World);
        if(rotateTogether != null)
        {
            if (rotateTogether.isOn)
            {
                for (int i = 1; i < target.Length; i++)
                    target[i].transform.Rotate(x, y, z, Space.World);
            }
        }
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
