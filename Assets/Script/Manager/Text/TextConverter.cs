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
    WordCompiler wordCompiler = new WordCompiler();
    public TMP_InputField inputField;
    public BottomSheet bottomSheet;

    public void Start()
    {

        contents.SetActive(false);
        inputField.onSubmit.AddListener(delegate { LockInput(inputField); });
    }
    void LockInput(TMP_InputField input)
    {
        string[] convertedText = wordCompiler.ConvertWord(wordConverter.TextToPhonemes(input.text));
        btnControler.EnPros = convertedText;
        for(int i = 0; i < convertedText.Length; i++)
        {

            Debug.Log(convertedText[i]);
        }
        btnControler.SetAllBtn();
        word.SetText(input.text);
        Close();
    }
    void Close()
    {
        contents.SetActive(true);
        bottomSheet.Close();
    }
}
