using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChangerList : MonoBehaviour
{
    public TextChanger[] textchanger;
    public void SetTextArray(string[] explains)
    {
        for(int i = 0; i < textchanger.Length; i++) { textchanger[i].gameObject.SetActive(false); }
        for(int i = 0; i < explains.Length; i++)
        {
            textchanger[i].SetText(explains[i]);
            textchanger[i].gameObject.SetActive(true);
        }
    }
}
