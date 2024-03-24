using System;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelector : MonoBehaviour
{
    public TextChanger currentIPA;
    public GameObject ModelList;
    public GameObject BackBtn;
    public GameObject ModelExplain;
    public ModelInfo TestModel;
    ModelInfo[] modelInfos;
    ModelInfo currentModel;

    private void Start()
    {
        modelInfos = ModelList.GetComponentsInChildren<ModelInfo>();
        for (int i = 0; i < modelInfos.Length; i++) { modelInfos[i].gameObject.SetActive(false); }
    }

    public void ResetModel()
    {
        ToggleObj(false);
        currentIPA.SetText("");
        currentModel.ToggleModel(false);
        currentModel = null;
    }
    public void SetModel(string textValue)
    {
        //ModelInfo selectedModel = Array.Find(modelInfos, x => x.text == textValue);
        //ErrorHandler.TryError(selectedModel == null, "selectedModel is Null");
        currentModel = TestModel;
        currentModel.ToggleModel(true);
        ToggleObj(true);
        currentIPA.SetText(textValue);
    }
    void ToggleObj(bool isOn)
    {
        BackBtn.SetActive(isOn);
        ModelExplain.SetActive(isOn);
    }
}
