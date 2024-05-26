using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswerBtn : MonoBehaviour
{
    public TextChanger text;
    public Image Frame;
    public Image Btn;

    public void SetText(string text)
    {
        ResetColor();
        this.text.SetText(text);
    }
    void ResetColor()
    {
        Frame.gameObject.SetActive(false);
        Btn.color = Color.white;
    }
    public void SelectBtn()
    {
        Btn.color = new Color(0.8f, 0.8f, 0.8f);
    }
    public void SetFrameColor(bool isCorrect)
    {
        Frame.gameObject.SetActive(true);
        Frame.color = isCorrect ? Color.green : Color.red;
    }
}
