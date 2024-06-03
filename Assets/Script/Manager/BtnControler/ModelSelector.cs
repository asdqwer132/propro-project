using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class ModelSelector : MonoBehaviour
{
    public IPAExplainPopup popup;
    JsonManager jsonManager = new JsonManager();
    public Explain ipaEx;
    private void Start()
    {
        ipaEx = jsonManager.Convert<Explain>("Assets/Data/IPAEx.Json");
    }
    public void ResetModel()
    {
        popup.Cancel();
    }
    public void SetModel(string text)
    {
        IPAEx explain = ipaEx.IPAEx.Find(x => x.ipa == text);
        Debug.Log(explain.ipa + "/" + explain.explain[0]);
        string[] explainText = explain.explain.ToArray();
        popup.SetIPA(text, explainText);
        popup.Open();
    }
}
