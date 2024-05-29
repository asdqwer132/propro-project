using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAnimationControler : MonoBehaviour
{
    public TextChanger text;
    WordConverter wordConverter;
    Head head;
    private void Awake()
    {
        ManagerFInder fInder = new ManagerFInder();
        head = fInder.GetComponetWithTag<Head>("model");
        wordConverter = fInder.GetComponetWithTag<WordConverter>("manager");
        //head = GameObject.FindWithTag("model").GetComponent<Head>();
        //wordConverter = GameObject.FindWithTag("manager").GetComponent<WordConverter>();
    }
    public void PlayAnimation()
    {
        string[] convertedText = wordConverter.TextToPhonemes(text.GetText());
        head.IpaArray = convertedText;
        head.PlayAnimations();
    }
    public void PlayIPAAnimation()
    {
        string[] convertedText = { text.GetText() };
        head.IpaArray = convertedText;
        head.PlayAnimations();
    }
}
