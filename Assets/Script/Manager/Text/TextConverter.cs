using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextConverter : MonoBehaviour
{
    public GameObject contents;
    public TextChanger word;
    public ProBtnControler btnControler;
    public TMP_InputField inputField;
    public BottomSheet bottomSheet;
    public Log log;
    public WordConverter wordConverter;
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
        string[] convertedText = wordConverter.TextToPhonemes(value);
        btnControler.EnPros = convertedText;
        btnControler.SetAllBtn();
        Debug.Log("here" + value);
        word.SetText(value);
        Debug.Log("here" + word.GetText());
        Close();
    }
    void Close()
    {
        contents.SetActive(true);
        bottomSheet.Close();
    }
}
