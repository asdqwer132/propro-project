using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : Popup
{
    public GameObject main;
    public TextChangerList textChangerList;
    private void Start()
    {
        Cancel();
        string[] ageValues = new string[100];
        for(int i = 0; i < ageValues.Length; i++)
        {
            ageValues[i] = "" + (i + 1);
        }
        textChangerList.SetTextArray(ageValues);
    }
    public void OpenSet()
    {
        Open();
        main.SetActive(false);
    }
    public void CloseSet()
    {
        Cancel();
        main.SetActive(true);
    }
}
