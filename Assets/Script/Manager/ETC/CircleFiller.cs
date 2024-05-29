using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleFiller : MonoBehaviour
{
    public Image circle;
    public void InitCircle(float value) { circle.fillAmount = value; }
    public void SetCircle(float value) { circle.fillAmount += value; }
    public float GetCircle() { return circle.fillAmount; }
}
