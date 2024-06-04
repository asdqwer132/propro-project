using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TTSManager : RunJets
{
    public TMP_InputField inputField;
    public TextMeshProUGUI text;
    public Head head;
    const float samplingRate = 22050;

    public void SpeakWord()
    {
        inputText = inputField.text;
        float[] audio = TextToSpeech();
        head.Duration = audio.Length / samplingRate;
    }
    public void SpeakIPA()
    {
        inputText = text.text;
        float[] audio = TextToSpeech();
        head.Duration = audio.Length / samplingRate;
    }
    public void SpeakText(string value)
    {
        inputText = value;
        float[] audio = TextToSpeech();
        head.Duration = audio.Length / samplingRate;
    }
}
