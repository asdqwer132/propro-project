using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChangerList : MonoBehaviour
{
    public TextChanger[] textchanger;
    public TextLegucyChanger[] textLchanger;
    public void SetTextArray(string[] explains)
    {
        for (int i = 0; i < textchanger.Length; i++) { textchanger[i].gameObject.SetActive(false); }
        for (int i = 0; i < explains.Length; i++)
        {
            textchanger[i].SetText(explains[i]);
            textchanger[i].gameObject.SetActive(true);
        }
    }
    public void SetLTextArray(string[] explains)
    {
        for (int i = 0; i < textLchanger.Length; i++) { textLchanger[i].gameObject.SetActive(false); }
        for (int i = 0; i < explains.Length; i++)
        {
            textLchanger[i].SetText(explains[i]);
            textLchanger[i].gameObject.SetActive(true);
        }
    }
}
