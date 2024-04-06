using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextConverter : MonoBehaviour
{
    public GameObject contents;
    public TextChanger word;
    public ProBtnControler btnControler;
    public WordConverter wordConverter;
    public WordCompiler wordCompiler;
    public TMP_InputField inputField;
    public BottomSheet bottomSheet;
    bool isOpen = false;

    public void Start()
    {

        contents.SetActive(false);
        inputField.onSubmit.AddListener(delegate { LockInput(inputField); });
    }
    void LockInput(TMP_InputField input)
    {
        string[] convertedText = wordCompiler.ConvertWord(wordConverter.TextToPhonemes(input.text));
        btnControler.EnPros = convertedText;
        btnControler.SetAllBtn();
        word.SetText(input.text);
        Close();
        isOpen = true;
    }
    void Close()
    {
        contents.SetActive(true);
        bottomSheet.Close();
    }
}
