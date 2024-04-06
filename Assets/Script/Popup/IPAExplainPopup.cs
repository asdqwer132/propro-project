using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IPAExplainPopup : Popup
{
    public TextChanger currentIPA;
    public TextSelector explainText;
    public void SetIPA(string ipa, string[] explains)
    {
        currentIPA.SetText(ipa);
        explainText.SetTextArray(explains);
    }
}
