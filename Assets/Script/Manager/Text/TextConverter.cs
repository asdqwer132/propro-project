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
    public Log log;
    public void Start()
    {

        contents.SetActive(false);
        inputField.onSubmit.AddListener(delegate { LockInput(inputField); });
    }
    public void SearchWIthLog(int index)
    {
        string searchWord = log.GetLog(index);
        StartCoroutine(Delay(searchWord));
    }
    IEnumerator Delay(string searchWord)
    {
        yield return new WaitForSeconds(0.1f);
        Convert(searchWord);
        inputField.text = searchWord;

    }
    void LockInput(TMP_InputField input)
    {
        Convert(input.text);
        log.AddLog(input.text);
    }
    void Convert(string value)
    {
        string[] convertedText = wordCompiler.ConvertWord(wordConverter.TextToPhonemes(value));
        btnControler.EnPros = convertedText;
        //for (int i = 0; i < convertedText.Length; i++)
        //{
        //    Debug.Log(convertedText[i]);
        //}
        btnControler.SetAllBtn();
        word.SetText(value);
        Close();
    }
    void Close()
    {
        contents.SetActive(true);
        bottomSheet.Close();
    }
}
