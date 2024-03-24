using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInfo : MonoBehaviour
{
    public string text;
    public GameObject modelObj;

    public void ToggleModel(bool isOn) { modelObj.SetActive(isOn); }
}
