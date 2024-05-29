using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ProBtnControlerAllIPA : ProBtnControler
{
    WordCompiler compiler = new WordCompiler();
    JsonManager jsonManager = new JsonManager();
    public string fileName;
    void Start()
    {
        IPA tmp = jsonManager.Convert<IPA>(fileName);
        string[] EnProsList = tmp.IPAList.ToArray();

        //Debug.Log(EnProsList[0]);
        EnPros = compiler.ConvertWord(EnProsList);
        SetAllBtn();
    }
}
