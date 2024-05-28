using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public TextChanger[] logs = new TextChanger[10];

    int currentLogCnt = 0;

    public string GetLog(int index) { if (logs.Length > currentLogCnt) return logs[index].GetText(); return "none"; }
    public void AddLog(string value)
    {
        for(int i = 0; i < logs.Length; i++)
        {
            if(logs[i].GetText() == value)
            {
                return;
            }
        }
        if(logs.Length > currentLogCnt)
        {
            logs[currentLogCnt].gameObject.SetActive(true);
            logs[currentLogCnt].SetText(value);
            currentLogCnt++;
        }
        else
        {
            for(int i = 0; i < logs.Length-1; i++)
            {
                logs[i].SetText(logs[i+1].GetText());
            }
            logs[logs.Length - 1].SetText(value);
        }
    }
    
}
