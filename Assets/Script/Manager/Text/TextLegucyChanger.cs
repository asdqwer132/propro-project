using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLegucyChanger : MonoBehaviour
{
    [SerializeField] Text text;
    public void SetText(string value)
    {
        text.text = value;
    }
    public void SetColor(Color color)
    {
        text.color = color;
    }
    public string GetText() { return text.text; }
}
