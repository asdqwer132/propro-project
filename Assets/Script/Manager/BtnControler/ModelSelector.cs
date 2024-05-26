using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModelSelector : MonoBehaviour
{
    public IPAExplainPopup popup;

    public void ResetModel()
    {
        popup.Cancel();
    }
    public void SetModel(string text)
    {
        popup.SetIPA(text, new string[] { "test1", "test2"});
        popup.Open();
    }
}
