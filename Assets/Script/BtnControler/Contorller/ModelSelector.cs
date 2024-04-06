using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModelSelector : MonoBehaviour
{
    public Model model;
    public IPAExplainPopup popup;

    public void ResetModel()
    {
        model.ToggleModel(false);
        popup.Cancel();
    }
    public void SetModel(string text)
    {
        model.ToggleModel(true);
        popup.SetIPA(text, new string[] { "test1", "test2"});
        popup.Open();
    }
}
