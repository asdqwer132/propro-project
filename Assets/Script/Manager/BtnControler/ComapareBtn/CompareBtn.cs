using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareBtn : MonoBehaviour
{
    public string explain;
    public string IPA1;
    public string IPA2;
    public TextChanger IPA1Text;
    public TextChanger IPA2Text;
    private void Start()
    {
        IPA1Text.SetText(IPA1);
        IPA2Text.SetText(IPA2);
    }
}
