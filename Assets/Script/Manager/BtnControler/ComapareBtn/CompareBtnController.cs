using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareBtnController : MonoBehaviour
{
    public GameObject[] navi;
    public GameObject list;
    public GameObject IPAs;
    public ProBtn IPA1;
    public ProBtn IPA2;
    public ProBtnFunc btnFunc;
    public TextLegucyChanger explain;
    public CompareBtn[] compareBtns;
    private void Start()
    {
        TurnOnIPAs(false);
        IPA1.InitBtn(0, btnFunc);
        IPA2.InitBtn(1, btnFunc);
    }
    public void ShowExplain(int index)
    {
        TurnOnIPAs(true);
        IPA1.SetBtn(compareBtns[index].IPA1);
        IPA2.SetBtn(compareBtns[index].IPA2);
        explain.SetText(compareBtns[index].explain);
    }
    public void TurnOnIPAs(bool isOn)
    {
        IPAs.SetActive(isOn);
        list.SetActive(!isOn);
        navi[0].SetActive(!isOn);
        navi[1].SetActive(isOn);
    }
}
