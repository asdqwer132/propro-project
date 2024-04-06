using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public GameObject modelObj;
    public void ToggleModel(bool isOn) { modelObj.SetActive(isOn); }
}
