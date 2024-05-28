using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAnimationControler : MonoBehaviour
{
    public TextChanger text;
    WordConverter wordConverter;
    Head head;
    private void Start()
    {
        head = GameObject.FindWithTag("model").GetComponent<Head>();
        wordConverter = GameObject.FindWithTag("manager").GetComponent<WordConverter>();
    }
    public void PlayAnimation()
    {
        string[] convertedText = wordConverter.TextToPhonemes(text.GetText());
        head.IpaArray = convertedText;
        head.PlayAnimations();
    }
}
