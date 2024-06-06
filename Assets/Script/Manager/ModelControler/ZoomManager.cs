using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    //public SliderControler slider;
    public Transform model;
    public float maxSize = 3200;
    public float minSize = 900;
    public float chanfeValue = 5;
    public float offset = 0;
    public float originSize = 1600;
    bool isZoomIn, isZoomOut;
    private void Start()
    {
        model.localScale = new Vector3(originSize, originSize, originSize);
    }
    private void Update()
    {
        if (isZoomIn)
        {
            if (maxSize > model.localScale.x)
            {
                model.localScale = new Vector3(originSize + chanfeValue, originSize + chanfeValue, originSize + chanfeValue);
            }
            originSize = model.localScale.x;
        }
        if (isZoomOut)
        {
            if (minSize < model.localScale.x)
            {
                model.localScale = new Vector3(originSize - chanfeValue, originSize - chanfeValue, originSize - chanfeValue);
            }
            originSize = model.localScale.x;
        }
        model.localPosition = new Vector3(0, -(originSize / 10) + offset, -(originSize / 30));
    }
    public void PointUp() { isZoomOut = false; isZoomIn = false; }

    public void ZoomIn() { isZoomIn = true; }
    public void ZoomOut() { isZoomOut = true; }
}
