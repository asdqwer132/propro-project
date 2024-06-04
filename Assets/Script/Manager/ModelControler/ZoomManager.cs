using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    //public SliderControler slider;
    public Transform model;
    public float maxSize;
    public float minSize;
    public float offset = 5;
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
            if (maxSize > model.localScale.x) model.localScale = new Vector3(originSize + offset, originSize + offset, originSize + offset);
            originSize = model.localScale.x;
        }
        if (isZoomOut)
        {
            if (minSize < model.localScale.x) model.localScale = new Vector3(originSize - offset, originSize - offset, originSize - offset);
            originSize = model.localScale.x;
        }
    }
    public void PointUp() { isZoomOut = false; isZoomIn = false; }

    public void ZoomIn() { isZoomIn = true; }
    public void ZoomOut() { isZoomOut = true; }
}
