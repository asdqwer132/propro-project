using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBtnFunc : MonoBehaviour
{
    public GameObject ToggleBtn;
    public GameObject IPAList;
    public ModelSelector modelSelector;

    public void BackToList()
    {
        ToggleList(true);
        modelSelector.ResetModel();
    }
    public void SetModel(string text)
    {
        ToggleList(false); ;
        modelSelector.SetModel(text);
    }
    void ToggleList(bool isOn)
    {
        ToggleBtn.SetActive(isOn);
        IPAList.SetActive(isOn);
    }
}
