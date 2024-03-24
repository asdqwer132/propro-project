using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBtnControler : MonoBehaviour
{
    public GameObject proBtnList;
    string[] enPros = { "a", "e", "æ", "i", "ɔ", "u", "ə", "Λ", "a:", "i:", "ɔ:", "u:", "ə:", "ai", "ei" };
    ProBtn[] proBtns;
    private void Start()
    {
        proBtns = proBtnList.GetComponentsInChildren<ProBtn>();
        SetAllBtn(GetComponent<ProBtnFunc>());
    }
    void SetAllBtn(ProBtnFunc func)
    {
        int i = 0;
        for(i = 0; i < enPros.Length; i++)
        {
            proBtns[i].SetBtn(i, enPros[i],func);
        }
        for (; i < proBtns.Length; i++) proBtns[i].gameObject.SetActive(false);
    }
}
