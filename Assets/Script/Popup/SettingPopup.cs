using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : Popup
{
    public GameObject main;

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
