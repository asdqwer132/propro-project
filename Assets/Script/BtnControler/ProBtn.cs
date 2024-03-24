using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBtn : MonoBehaviour
{
    int index;
    TextChanger text;
    ProBtnFunc func;
    public void SetBtn(int value, string textValue, ProBtnFunc controler)
    {
        func = controler;
        InitBtn();
        SetValueBtn(value, textValue);
    }
    public void TrySetModel() { func.SetModel(text.GetText()); }
    #region 버튼 텍스트 설정
    void InitBtn()
    {
        text = GetComponent<TextChanger>();
    }
    void SetValueBtn(int value, string textValue)
    {
        index = value;
        text.SetText(textValue);
    }
    #endregion

}
