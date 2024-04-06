using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBtnControler : MonoBehaviour
{
    public GameObject proBtnList;
    public ProBtnFunc func;
    string[] enPros;
    ProBtn[] proBtns;

    public string[] EnPros { get => enPros; set => enPros = value; }

    private void Awake()
    {
        proBtns = proBtnList.GetComponentsInChildren<ProBtn>();
        ResetAllBtn(func);
    }
    void ResetAllBtn(ProBtnFunc func)
    {
        for (int i = 0; i < proBtns.Length; i++)
        {
            proBtns[i].InitBtn(i, func);
            proBtns[i].gameObject.SetActive(false);
        }
    }
    public void SetAllBtn()
    {
        int i = 0;
        for (i = 0; i < EnPros.Length; i++)
        {
            proBtns[i].SetBtn(EnPros[i]);
            proBtns[i].gameObject.SetActive(true);
        }
        for (; i < proBtns.Length; i++) proBtns[i].gameObject.SetActive(false);
    }
}
