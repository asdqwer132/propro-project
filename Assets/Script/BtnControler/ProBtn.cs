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
    #region ��ư �ؽ�Ʈ ����
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
