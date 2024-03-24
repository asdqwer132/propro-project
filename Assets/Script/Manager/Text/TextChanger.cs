using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextChanger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public void SetText(string value)
    {
        text.text = value;
    }
    public string GetText() { return text.text; }
}
