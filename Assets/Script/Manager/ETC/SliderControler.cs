using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControler : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    public void Slide(float duration)
    {
        slider.value = 0;
        StartCoroutine(SlideWithDelay(1f / (100 * duration)));
    }
    IEnumerator SlideWithDelay(float offset)
    {
        while(slider.value < 1f)
        {
            slider.value += offset;
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void SetValue(float valuu) { slider.value = valuu; }
    public float GetValue() { return slider.value; }
}
