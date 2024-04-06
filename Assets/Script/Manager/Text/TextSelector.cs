using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextSelector : TextChanger
{
    public TextChanger indexText;
    public Button nextBtn;
    public Button prevBtn;
    public string[] texts = { "English", "China", "ETC"};
    int index;
    private void Start()
    {
        nextBtn.onClick.AddListener(Next);
        prevBtn.onClick.AddListener(prev);
    }
    public void Next()
    {
        MoveIndex(true);
        SetText(texts[index]);
    }
    public void prev()
    {
        MoveIndex(false);
        SetText(texts[index]);
    }
    public void SetTextArray(string[] newTexts)
    {
        texts = newTexts;
        SetText(texts[0]);
        indexText.SetText("1" + "/" + texts.Length);
    }
    void MoveIndex(bool isPlus)
    {
        index += isPlus ? 1 : -1;
        if (index == texts.Length) index = 0;
        else if (index < 0) index = texts.Length - 1;
        if(indexText != null )indexText.SetText((index + 1)+ "/" + texts.Length);
    }
}
