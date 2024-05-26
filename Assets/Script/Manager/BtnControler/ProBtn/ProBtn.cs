using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProBtn : MonoBehaviour
{
    int index;
    //Button thisBtn;
    ProBtnFunc func;
    public TextChanger text;
    public void InitBtn(int value, ProBtnFunc controler)
    {
        func = controler;
        InitBtn();
        index = value;
    }
    public void TrySetModel() { func.SetModel(text.GetText()); }
    #region 버튼 텍스트 설정
    void InitBtn()
    {
        text = GetComponent<TextChanger>();
       // thisBtn = GetComponent<Button>();
    }
    public void SetBtn(string newText)
    {
        text.SetText(newText);
    }
    #endregion

}
