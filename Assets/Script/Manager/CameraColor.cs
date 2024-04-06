using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    public Color[] colors;
    public void SetColor(int index)
    {
        Camera.main.backgroundColor = colors[index];
    }
}
