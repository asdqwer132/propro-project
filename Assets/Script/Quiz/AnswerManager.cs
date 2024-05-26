using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswerManager : MonoBehaviour
{
    public TextLegucyChanger answer;
    public AnswerBtn[] answeList;
    public void SetAnswer(string[] answeList)
    {
        answer.gameObject.SetActive(false);
        for (int i = 0; i < answeList.Length; i++)
        {
            this.answeList[i].SetText(answeList[i]);
        }
    }
    public bool CheckAnswer(int index, int correctIndex)
    {
        answer.gameObject.SetActive(true);
        //answeList[index].SelectBtn();
        answeList[correctIndex].SetFrameColor(true);
        if (index == correctIndex)
        {
            answer.SetColor(Color.green);
            answer.SetText("정답!");
            return true;
        }
        else
        {
            answer.SetColor(Color.red);
            answer.SetText("오답!");
            answeList[index].SetFrameColor(false);
            return false;
        }
    }
}
