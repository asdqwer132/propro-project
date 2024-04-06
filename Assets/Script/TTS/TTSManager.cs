using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TTSManager : RunJets
{
    public TMP_InputField inputField;
    public TextMeshProUGUI text;
    public void SpeakWord()
    {
        inputText = inputField.text;
        TextToSpeech();
    }
    public void SpeakIPA()
    {
        inputText = text.text;
        TextToSpeech();
    }
    public void SpeakText(string value)
    {
        inputText = value;
        TextToSpeech();
    }
}
