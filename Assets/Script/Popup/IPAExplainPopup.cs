using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;
public class IPAExplainPopup : Popup
{
    public GameObject[] parents;
    public GameObject[] lists;
    public GameObject[] contents;
    public SimpleScrollSnap scrollSnap;
    public TextChanger currentIPA;
    public TextChangerList explainText;

    public void SetIPA(string ipa, string[] explains)
    {
        currentIPA.SetText(ipa);
        explainText.SetLTextArray(explains);
        for (int i = 0; i < lists.Length; i++)
        {
            contents[i].transform.SetParent(parents[0].transform);
            lists[i].SetActive(false);
        }
        for (int i = 0; i < explains.Length; i++)
        {
            contents[i].transform.SetParent(parents[1].transform);
            lists[i].SetActive(true);
        }
        scrollSnap.Setup();
    }
}
