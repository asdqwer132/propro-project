using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModelSelector : MonoBehaviour
{
    public Model model;
    public Button backBtn;
    public IPAExplainPopup popup;

    public void ResetModel()
    {
        backBtn.interactable = false;
        model.ToggleModel(false);
        popup.Cancel();
    }
    public void SetModel(string text)
    {
        backBtn.interactable = true;
        model.ToggleModel(true);
        popup.SetIPA(text, new string[] { "test1", "test2"});
        popup.Open();
    }
}
