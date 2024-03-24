using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextConverter : TextChanger
{
    public WordConverter wordConverter;
    public TMP_InputField inputField;
    public void Start()
    {
        inputField.onSubmit.AddListener(delegate { LockInput(inputField); });
    }
    void LockInput(TMP_InputField input)
    {
        SetText(wordConverter.WordToIPA(inputField.text));
    }
}
