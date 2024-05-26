using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBtnTTS : ProBtn
{
    public TTSManager manager;
    public void TrySpeak()
    {
        manager.SpeakText(text.GetText());
    }

}
