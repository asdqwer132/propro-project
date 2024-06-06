using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    //public SliderControler slider;
    public Transform model;
    public float maxSize;
    public float minSize;
    public float chanfeValue = 5;
    public float offset = 0;
    float originSize;
    bool isZoomIn, isZoomOut;
    private void Start()
    {
        originSize = model.localScale.x;
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
        model.localPosition = new Vector3(0, -(originSize / 10) + offset, 0);
    }
    public void PointUp() { isZoomOut = false; isZoomIn = false; }

    public void ZoomIn() { isZoomIn = true; }
    public void ZoomOut() { isZoomOut = true; }
}
