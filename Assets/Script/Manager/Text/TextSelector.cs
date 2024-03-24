using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSelector : TextChanger
{
    string[] texts = { "English", "China", "ETC"};
    int index;
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
    void MoveIndex(bool isPlus)
    {
        index += isPlus ? 1 : -1;
        if (index == texts.Length) index = 0;
        else if (index < 0) index = texts.Length - 1;
    }
}
