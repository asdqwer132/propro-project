using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBtnFunc : MonoBehaviour
{
    public GameObject ToggleBtn;
    public GameObject IPAList;
    public ModelSelector modelSelector;
    public GameObject[] navi;

    public void BackToList()
    {
        ToggleList(true);
        SetNavi(true);
        modelSelector.ResetModel();
    }
    public void SetModel(string text)
    {
        ToggleList(false); ;
        SetNavi(false);
        modelSelector.SetModel(text);
    }
    void ToggleList(bool isOn)
    {
        ToggleBtn.SetActive(isOn);
        IPAList.SetActive(isOn);
    }
    void SetNavi(bool OpenPopup)
    {
        navi[0].SetActive(OpenPopup);
        navi[1].SetActive(!OpenPopup);
    }
}
